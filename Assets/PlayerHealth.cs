using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int healthPoints = 100;
    public int initHealthPoints;
    public AudioSource _audioSourceHealth;
    
	// Use this for initialization
	void Start () {
        initHealthPoints = healthPoints;
	}
	

    public void getDamage(int value)
    {
        if (!_audioSourceHealth.isPlaying)
        {
            _audioSourceHealth.Play();
        }
        
        healthPoints -= value;
        UIManager.instance.healthPoints = healthPoints;
    }

    public void resetHealthPoints()
    {
        healthPoints = initHealthPoints;
    }

}
