using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class trackTIme : MonoBehaviour
{

    public float currentTime = 0;
    public Text textBox;



    
    void Start()
    {
        textBox.text = "Time:" + currentTime.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        textBox.text = "Time:" + currentTime.ToString();
        /*
        if (pauseMenu.paused)
        {
            currentTime = currentTime;
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        
        textBox.text = "Time:" + currentTime.ToString();
        */
    }
}
