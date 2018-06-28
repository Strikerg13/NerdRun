using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenuController : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject startMenuUI;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Menu"))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
	}


    public void Resume()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void loadMenu()
    {
        print("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene2");
    }

    public void QuitGame()
    {
        print("Player has quit.");
        Application.Quit();
    }
}
