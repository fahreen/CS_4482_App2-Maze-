using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;

  
    private List<Transform> highscoreEntryTransformList;

    

    private void Awake()
    {


        //get reference to entry and container
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = transform.Find("HighScoreEntryTemplate");
        //entryTemplate = transform.FindChild("HighScoreEntryTemplate");

        // hide default template
        entryTemplate.gameObject.SetActive(false);


        // NEW ENTRY
        //if game over == true, add new score here!
        if(StateNameController.game_over == true)
        {
            AddHighScoreEntry(StateNameController.user_score, StateNameController.user_name);
        }

        StateNameController.game_over = false;
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores =  JsonUtility.FromJson<Highscores>(jsonString);

        //sort table
        
        for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highscores.highScoreEntryList.Count; j++)
            {
                if(highscores.highScoreEntryList[j].score < highscores.highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highScoreEntryList[i];
                    highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = tmp;
                }
            }
        }

        
        

        highscoreEntryTransformList = new List<Transform>();
        foreach( HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
        {
            CreateHighscoreEntryTransform(highScoreEntry, entryContainer, highscoreEntryTransformList);
        }

    
    }


    private void CreateHighscoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        float score = highScoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        string name = highScoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);

    }


    private class Highscores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }


    [System.Serializable]
    private class HighScoreEntry
    {
        public float score;
        public string name;
    }



    public void AddHighScoreEntry(float score, string name )
    {
        // create HighscoreEntry
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // add new entry to high score
        highscores.highScoreEntryList.Add(highScoreEntry);

        // save updated highscore
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }


    

        

}








 