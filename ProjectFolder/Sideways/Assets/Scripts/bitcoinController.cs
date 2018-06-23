using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bitcoinController : MonoBehaviour {

    public AudioSource coinSound;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            coinSound.Play();
            Destroy(this.gameObject);
        }
    }
}
