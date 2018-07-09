using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour {

    public GameObject player;
    public float playerX;
    public float playerY;
    float distanceToPlayer;
    float oldDistanceToPlayer;
    float changeInDistance;

	// Use this for initialization
	void Start () {
        Debug.Log("Hello, I'm an NPC");



        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerX = player.GetComponent<Transform>().position.x;
            playerY = player.GetComponent<Transform>().position.y;
            Debug.Log("I found the player. He's at (" + playerX.ToString() + "," + playerY.ToString() + ")");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        distanceToPlayer = (player.transform.position - this.transform.position).magnitude;

        if (distanceToPlayer != oldDistanceToPlayer)
        {
            changeInDistance = Mathf.Abs(oldDistanceToPlayer - distanceToPlayer);
            if (changeInDistance >= 0.5f)
            {
                Debug.Log("Leinad is " + distanceToPlayer.ToString("F2") + " away.");
                oldDistanceToPlayer = distanceToPlayer;
            }

        }

	}
}
