using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupBehavior : MonoBehaviour {

    public int itemSpeed;
    public int xMoveDirection;
    //public GameObject player;

    Transform itemTransform;
    float itemWidth;

    bool isBlocked;

	// Use this for initialization
	void Start () 
    {
        itemTransform = this.transform;
        itemWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
    void FixedUpdate()
    {
        // Are we blocked by something?
        isBlocked = checkBlocked(isBlocked);

        if (isBlocked)
        {
            // Walk the other way
            Flip();
        }

        Move();
    }

    bool checkBlocked(bool isBlocked)
    {
        if (itemSpeed > 0 && xMoveDirection != 0)
        {
            if (xMoveDirection > 0)
            {
                // Check if something is on the right.
                Vector2 lineCastPositionRight = itemTransform.position + (itemTransform.right * itemWidth);
                Vector2 itemRight = new Vector2(itemTransform.right.x, itemTransform.right.y);
                Debug.DrawLine(lineCastPositionRight, lineCastPositionRight - (itemRight * 0.04f), Color.white);
                isBlocked = Physics2D.Linecast(lineCastPositionRight, lineCastPositionRight - (itemRight * 0.04f));
            }
            else
            {
                // Check if something is on the left.
                Vector2 lineCastPositionLeft = itemTransform.position - (itemTransform.right * itemWidth);
                Vector2 itemLeft = new Vector2(itemTransform.right.x, itemTransform.right.y);
                Debug.DrawLine(lineCastPositionLeft, lineCastPositionLeft - (itemLeft * 0.04f), Color.white);
                isBlocked = Physics2D.Linecast(lineCastPositionLeft, lineCastPositionLeft - (itemLeft * 0.04f));
            }
        }
        else
        {
            isBlocked = false;
        }

        return isBlocked;
    }

    // Move forward
    void Move()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * itemSpeed;
    }

    // Change direction
    void Flip()
    {
        xMoveDirection = -1 * xMoveDirection;
    }


}
