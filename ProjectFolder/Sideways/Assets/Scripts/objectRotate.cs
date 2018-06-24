using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRotate : MonoBehaviour {

    public float rotationsPerMinute = 10.0f;
    public bool rotateRight = true;


    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotate();
	}

    void rotate()
    {
        float direction;
        if (rotateRight == true)
            direction = -1.0f;
        else
            direction = 1.0f;
        
        this.transform.Rotate(0.0f, 0.0f, 6.0f * rotationsPerMinute * Time.deltaTime * direction);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        col.transform.parent = this.transform;

    }

    void OnCollisionExit2D (Collision2D col)
    {
        col.transform.parent = null;
    }
}
