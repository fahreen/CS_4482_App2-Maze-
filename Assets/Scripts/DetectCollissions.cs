using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class DetectCollissions : MonoBehaviour
{
    bool haveKey;
    public Camera mainCam;
    private trackTIme timerScript;
    //public int score;

    void Start()
    {
        haveKey = false;
        timerScript = mainCam.GetComponentInChildren<trackTIme>();
        
        
    }


  


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("start")) {
            Debug.Log("Start");
            Destroy(other.gameObject);
            // start timer 
            //show time on screen
        }

        else if (other.CompareTag("end"))
        {
            Debug.Log("end");
            Destroy(other.gameObject);
            //save score
            StateNameController.user_score = timerScript.currentTime;
            StateNameController.game_over = true;
            SceneManager.LoadScene("EnterScore");


            // float score = timerScript.currentTime;
            //Load leaderboard screen
        }

        else if (other.CompareTag("key"))
        {
            Debug.Log("key");
            haveKey = true;  //set key bool value to true
            Destroy(other.gameObject); //make key dissapear

            

        }


    }




    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("door"))
        {
            if (haveKey)
            {
                Debug.Log("door");
                Destroy(collision.gameObject);
                haveKey = false;
            }
        }
    }
}
