using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour {

    public static bool GameIsPaused = false;
    public Transform PauseScreen;
    playerBehavior playerController;


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

        // highlight the button you want to start as selected
        setFocusToFirstControl("UIInitialFocusControl", "UI2ndFocusControl");

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

    // trick to make the 1st button highlighted when the menu appears
    public void setFocusToFirstControl(string firstControlsTag, string secondControlsTag)
    {
        Button btnSelect;       // The button we want to start out selected
        Button btnDontSelect;   // The button we want to switch to and from

        // find the controls
        btnSelect = GameObject.FindGameObjectWithTag(firstControlsTag).GetComponent<Button>();
        btnDontSelect = GameObject.FindGameObjectWithTag(secondControlsTag).GetComponent<Button>();

        // cycle selection to make the Select button highlighted when the menu appears
        btnDontSelect.Select();
        btnSelect.Select();
    }
}
