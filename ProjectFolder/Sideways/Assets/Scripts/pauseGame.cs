using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour {

    public static bool GameIsPaused = false;
    public Transform PauseScreen;
    public playerBehavior playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerBehavior>();
    }

	// Update is called once per frame
	void Update () 
    {
		if (Input.GetButtonDown("Menu")) 
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

        // stop the player from moving
        playerController.freezePlayer(true);

        // show pause screen
        PauseScreen.gameObject.SetActive(true);

        // let everyone know
        GameIsPaused = true;
    }

    public void Unpause()
    {
        // unpause time
        Time.timeScale = 1;   

        // hide pause screen
        PauseScreen.gameObject.SetActive(false);

        // let the player move again
        playerController.freezePlayer(false);

        // let everyone know
        GameIsPaused = false;
    }

    public void quitGame()
    {
        print("Player has quit.");
        Application.Quit();
    }
}
