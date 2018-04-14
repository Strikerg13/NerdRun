using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    public int health;

    void Start ()
    {
        health = 100;
    }

	// Update is called once per frame
	void Update () 
    {
        Fall();
        enemyDamage();
	}

    // Take off health if player touches an enemy.
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            float playerHeight = gameObject.GetComponent<Transform>().position.y;
            float enemyHeight = col.gameObject.GetComponent<Transform>().position.y;

            float playerRadius = gameObject.GetComponent<CircleCollider2D>().radius;

            if ((playerHeight - (playerRadius * 0.5f)) >= enemyHeight)
            {
                Destroy(col.gameObject);
            }
            else
            {
                health -= 100;
            }

        }
        //else if (col.gameObject.tag == "powerup")
        //{
           // Destroy(col.gameObject);
        //}
    }




    void Die () 
    {
        SceneManager.LoadScene("Scene1");
    }

    // Die if the player falls below the level.
    void Fall ()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }
        
    // Player dies if they have no health.
    void enemyDamage()
    {
        if (health <= 0)
        {
            Die();
        }
        if (health < 100)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(146, 27, 0);
        }
    }
}
