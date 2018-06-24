using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persistentMusic : MonoBehaviour {

    static bool AudioBegin = false;

    void Awake()
    {
        if (!AudioBegin)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(this.gameObject);
            AudioBegin = true;
        }

    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        if (SceneManager.GetActiveScene().name == "Scene1")
//        {
//            this.gameObject.GetComponent<AudioSource>().Stop();
//            AudioBegin = false;
//        }
	}
}
