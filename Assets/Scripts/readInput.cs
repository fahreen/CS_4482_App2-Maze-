using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class readInput : MonoBehaviour
{
 
    public void ReadStringInput(string s)
    {
        StateNameController.user_name = s;
        Debug.Log(StateNameController.user_name);
    }

    public void LoadLB()
    {
        SceneManager.LoadScene("Leaderboard");
        //timeValueScript = avatar.GetComponent<DetectCollissions>();
        // Debug.Log(timeValueScript.score);

    }

}
