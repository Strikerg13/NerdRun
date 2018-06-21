using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileBehavior : MonoBehaviour {

    public Sprite fileOpen;
    public GameObject powerup;
    bool isOpened;
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D (Collision2D col)
    {
        checkOpened();

        if (!isOpened)
        {
            if (col.gameObject.tag == "Player")
            {
                float fileHeight = gameObject.GetComponent<Transform>().position.y;
                float playerHeight = col.gameObject.GetComponent<Transform>().position.y;
                float playerRadius = col.gameObject.GetComponent<CircleCollider2D>().radius;

                if ((playerHeight + (playerRadius * 0.5f)) <= fileHeight)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = fileOpen;

                    powerup.SetActive(true);
                }
            }
        }
    }

    void checkOpened()
    {
        Sprite currentSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;

        if (currentSprite == fileOpen)
        {
            isOpened = true;
        }
        else
        {
            isOpened = false;
        }
    }
}
