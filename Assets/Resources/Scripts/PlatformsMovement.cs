using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMovement : MonoBehaviour {


    public Transform[] transforms;
    public Vector3 position1;
    public Vector3 position2;
    public bool lateralMovement;
    public bool verticalMovement;
    public float velocity;

    public bool changeDirection;

    private float initialY;
    private float initialX;
    private float velocityX;
    private float velocityY;

    private GameObject player;

    public bool collidingWithPlayer = false;

    public float separatingPlayerPlatform;

    private Collider _collider;

	// Use this for initialization
	void Start () {
        transforms = GetComponentsInChildren<Transform>();
        position1 = transforms[1].transform.position;
        position2 = transforms[2].transform.position;
        initialY = position1.y;
        initialX = position1.x;

        velocityX = (position2.x - position1.x) * velocity;
        velocityY = (position2.y - position1.y) * velocity;

        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    void OnTriggerStay(Collider c)
    {
       
        collidingWithPlayer = true;
    }

    // Update is called once per frame
    void FixedUpdate () {

        UpdatePlatformMovement();

        collidingWithPlayer = false;
    }

    private void UpdatePlatformMovement()
    {
        if (lateralMovement && verticalMovement)
        {
            if (this.transform.position.y <= position2.y && changeDirection)
            {
                //Debug.Log("Arriba");
                float y = this.transform.position.y + velocityY;
                float x = this.transform.position.x - velocityX;
                this.transform.position = new Vector3(x, y, this.transform.position.z);
                if (changeDirection && (position2.y - this.transform.position.y < 0.1f)) changeDirection = false;
                if (collidingWithPlayer)
                {

                    //Debug.Log("Col Play");
                    player.transform.position = new Vector3(player.transform.position.x - velocityX, player.transform.position.y + velocityY + separatingPlayerPlatform, player.transform.position.z);
                }

            }
            else if (this.transform.position.y >= initialY && !changeDirection)
            {
                //Debug.Log("Abajo");
                float y = this.transform.position.y - velocityY;
                float x = this.transform.position.x + velocityX;
                this.transform.position = new Vector3(x, y, this.transform.position.z);
                if (!changeDirection && (this.transform.position.y - initialY < 0.1f)) changeDirection = true;
                if (collidingWithPlayer)
                {
                    //player.transform.parent = this.transform;

                    //Debug.Log("Col Play");
                    player.transform.position = new Vector3(player.transform.position.x + velocityX, player.transform.position.y - velocityY + separatingPlayerPlatform, player.transform.position.z);

                }
            }
        }
        else if (verticalMovement)
        {
            if (this.transform.position.y <= position2.y && changeDirection)
            {
                //Debug.Log("Arriba");
                float y = this.transform.position.y + velocityY;
                this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
                if (changeDirection && (position2.y - this.transform.position.y < 0.1f)) changeDirection = false;

            }
            else if (this.transform.position.y >= initialY && !changeDirection)
            {
                //Debug.Log("Abajo");
                float y = this.transform.position.y - velocityY;
                this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
                if (!changeDirection && (this.transform.position.y - initialY < 0.1f)) changeDirection = true;
            }
        }
    }
}
