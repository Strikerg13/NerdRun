using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public float moveX;
    public float moveY;
    public bool isRunning;
	
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
        moveY = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        // Physics
        checkRunning();

        if (isRunning)
            moveX *= playerSpeed; // Full speed
        else
            moveX *= playerSpeed * 0.5f; // 1/2 speed
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
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
        
    void checkRunning()
    {
        if (Input.GetAxis("Right Trigger") > 0)
            isRunning = true;
        else
            isRunning = false;
    }
}
