using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {

    public int EnemySpeed;
    public int xMoveDirection;

    //Rigidbody2D enemyBody;
    Transform enemyTransform;
    float enemyWidth;

    bool isGrounded;
    bool isBlocked;

    void Start()
    {
        enemyTransform = this.transform;
        //enemyBody = this.GetComponent<Rigidbody2D>();
        enemyWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void FixedUpdate()
    {
        // Check if there's ground ahead.
        Vector2 lineCastPosition = enemyTransform.position - (enemyTransform.right * enemyWidth);
        Debug.DrawLine(lineCastPosition, lineCastPosition + Vector2.down, Color.white);
        isGrounded = Physics2D.Linecast(lineCastPosition, lineCastPosition + Vector2.down);

        // Check if something is ahead.
        Vector2 enemyRight = new Vector2(enemyTransform.right.x, enemyTransform.right.y);
        Debug.DrawLine(lineCastPosition, lineCastPosition - (enemyRight * 0.04f), Color.white);
        isBlocked = Physics2D.Linecast(lineCastPosition, lineCastPosition - (enemyRight * 0.04f));

        if (!isGrounded || isBlocked)
        {
            // Rotate the enemy around.
            Vector3 currentRotation = enemyTransform.eulerAngles;
            currentRotation.y += 180;
            enemyTransform.eulerAngles = currentRotation;

            // Walk the other way
            Flip();
        }

        Move();
    }

    // Move forward
    void Move()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
    }

    // Turn around
    void Flip()
    {
        xMoveDirection = -1 * xMoveDirection;
    }
}
