using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equationFriction : MonoBehaviour {

    public GameObject player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);

            // move twice as fast
            player.GetComponent<playerBehavior>().walkSpeed = 10;
            player.GetComponent<playerBehavior>().runSpeed = 20;

            // Smooth because dat friction makes you slick!
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        }
    }
}
