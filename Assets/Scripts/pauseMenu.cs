using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    
    public   bool paused = false;
    public GameObject panel;
    void Start()
    {
       panel.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape) && !paused) {
            Time.timeScale = 0;
            
        panel.gameObject.SetActive(true);
            paused = true;
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Time.timeScale = 1;
            panel.gameObject.SetActive(false);
            paused = false;
            

        }

    }
 
}
