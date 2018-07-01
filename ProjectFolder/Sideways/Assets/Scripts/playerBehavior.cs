using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

    public int runSpeed = 10;
    public int walkSpeed = 5;
    public bool facingRight = true;
    public float moveX;
    public float moveY;
    public bool isRunning;
    public Sprite walkSprite;
    public Sprite runSprite;
	
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
        {
            moveX *= runSpeed;
            gameObject.GetComponent<SpriteRenderer>().sprite = runSprite;
        }
        else
        {
            moveX *= walkSpeed;
            gameObject.GetComponent<SpriteRenderer>().sprite = walkSprite;
        }
        
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
        if (Input.GetAxis("Run") > 0)
            isRunning = true;
        else
            isRunning = false;
    }

    // Used to stop the player from moving
    public void freezePlayer(bool freeze)
    {
        if (freeze)
        {
            this.enabled = false;
            this.enabled = false;
        }
        else
        {
            this.enabled = true;
            this.enabled = true;
        }
    }
}
