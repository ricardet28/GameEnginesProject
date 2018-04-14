using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatcherSonAnimation : MonoBehaviour {
    public float rotateVel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(1, 0, 0) * rotateVel * Time.deltaTime);
	}
}
