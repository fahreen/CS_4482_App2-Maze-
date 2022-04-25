using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;



public class loadGame : MonoBehaviour




{

   // public GameObject avatar;
    //private DetectCollissions timeValueScript;

    public void LoadGame()
    {
        //pauseMenu.paused = false;
        Time.timeScale = 1;
        StateNameController.game_over = false;
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }


    public void LoadLB()
    {
        SceneManager.LoadScene("Leaderboard");
        //timeValueScript = avatar.GetComponent<DetectCollissions>();
       // Debug.Log(timeValueScript.score);

    }






}
