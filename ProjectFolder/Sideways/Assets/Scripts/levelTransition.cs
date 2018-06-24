using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour {

    public string nameOfNextLevel;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nameOfNextLevel);
        }
    }
}
