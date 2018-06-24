using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour {

    public static bool GameIsPaused = false;
    public Transform PauseScreen;

	// Update is called once per frame
	void Update () 
    {
		if (Input.GetButtonDown("Cancel")) 
        {
            if (!GameIsPaused)
                Pause();
            else
                Unpause();
		}


	}

    public void Pause()
    {
        // pause time
        Time.timeScale = 0;

        // show pause screen
        PauseScreen.gameObject.SetActive(true);

        GameIsPaused = true;
    }

    public void Unpause()
    {
        // unpause time
        Time.timeScale = 1;   

        // hide pause screen
        PauseScreen.gameObject.SetActive(false);

        GameIsPaused = false;
    }

    public void quitGame()
    {
        print("Player has quit.");
        Application.Quit();
    }
}
