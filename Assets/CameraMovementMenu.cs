using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementMenu : MonoBehaviour {
    public float speedTranslate;
    public Transform init;
    public Transform end;
	// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () {

        this.transform.Translate(0f, 0f, speedTranslate * Time.deltaTime);
        

	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("End"))
        {
            this.transform.position = init.position;
        }
    }
}
