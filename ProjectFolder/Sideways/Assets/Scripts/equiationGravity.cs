using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equiationGravity : MonoBehaviour {

    public GameObject player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);

            // jump twice as high
            player.GetComponent<betterJump>().jumpVelocity = 18.0f;

            // triggered cause gravity doesn't work like that!
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        }
    }
}
