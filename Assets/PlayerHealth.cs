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
    
    private bool playerIsAlive()
    {
        return healthPoints > 0 ? true : false;  
    }

    public void resetHealthPoints()
    {
        healthPoints = initHealthPoints;
    }
}
