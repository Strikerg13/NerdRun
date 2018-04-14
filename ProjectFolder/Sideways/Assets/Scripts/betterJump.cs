using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterJump : MonoBehaviour {

    public AudioSource jumpSound;

    public float fallMultiplier = 4.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity;
    public bool isGrounded;

    Rigidbody2D rb;
	
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () 
    {
        jump();
        alterVelocity();

	}



    // Basic jump move.
    void jump ()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            isGrounded = false;

            jumpSound.Play();
        }
    }

    // This adjusts the descent velocity depending on a short or long key press.
    void alterVelocity ()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
