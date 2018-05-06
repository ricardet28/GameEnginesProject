using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int healthPoints = 100;
    private int initHealthPoints;

    
	// Use this for initialization
	void Start () {
        initHealthPoints = healthPoints;
	}
	

    public void getDamage(int value)
    {
        healthPoints -= value;
    }

    public void resetHealthPoints()
    {
        healthPoints = initHealthPoints;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("detectando colisiones");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("RIP");
            getDamage(healthPoints);
        }
    }
}
