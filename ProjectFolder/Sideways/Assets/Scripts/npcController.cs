using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour {

    public GameObject player;
    public float otherObjectX;
    public float otherObjectY;
    float oldDistanceToObject;

	// Use this for initialization
	void Start () {
        Debug.Log("Hello, I'm an NPC");

        player = GameObject.FindGameObjectWithTag("Player");

        GetPositionOfAnObject(player);
	}
	
	// Update is called once per frame
	void Update () {
        
        GetDistanceToObject(player);
	}

    void GetPositionOfAnObject(GameObject otherObject)
    {
        if (otherObject != null)
        {
            otherObjectX = otherObject.GetComponent<Transform>().position.x;
            otherObjectY = otherObject.GetComponent<Transform>().position.y;
            Debug.Log("I found the player. He's at (" + otherObjectX.ToString() + "," + otherObjectY.ToString() + ")");
        }
    }

    void GetDistanceToObject(GameObject otherObject)
    {
        float distanceToObject;
        float changeInDistance;

        distanceToObject = (otherObject.transform.position - this.transform.position).magnitude;

        if (distanceToObject != oldDistanceToObject)
        {
            changeInDistance = Mathf.Abs(oldDistanceToObject - distanceToObject);
            if (changeInDistance >= 0.5f)
            {
                Debug.Log("Leinad is " + distanceToObject.ToString("F2") + " away.");
                oldDistanceToObject = distanceToObject;
            }

        }

    }
}
