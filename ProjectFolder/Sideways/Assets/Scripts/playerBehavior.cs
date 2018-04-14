﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public float moveX;
	
	// Update is called once per frame
	void Update () 
    {
        PlayerMove();
        turnAround();
	}

    void PlayerMove()
    {
        // Controls
        moveX = Input.GetAxis("Horizontal");

        // Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void turnAround()
    {
        if (moveX > 0.0f && facingRight == false)
        {
            flipPlayer();
        }
        else if (moveX < 0.0f && facingRight == true)
        {
            flipPlayer();
        }
    }

    void flipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
        
}
