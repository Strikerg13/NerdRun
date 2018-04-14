using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour {

    public Transform PauseScreen;
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetButtonDown("Cancel")) 
        {
            Pause();
		}
	}

    public void Pause()
    {
        if (Time.timeScale == 1)  
        {
            // pause time
            Time.timeScale = 0;

            // show pause screen
            PauseScreen.gameObject.SetActive(true);
        }
        else
        {
            // unpause time
            Time.timeScale = 1;   

            // hide pause screen
            PauseScreen.gameObject.SetActive(false);
        }
    }

    public void quitGame()
    {
        print("Player has quit.");
        Application.Quit();
    }
}
