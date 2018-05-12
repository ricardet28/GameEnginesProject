using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    public int damagePlayerValue = 5;
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            other.gameObject.GetComponent<PlayerHealth>().getDamage(damagePlayerValue);

            UIManager.instance.setTargetColorHealthBar();
            StartCoroutine(UIManager.instance.decreaseHealthBar());
            disableCollider();
            disableMesh();
            Destroy(this.gameObject, 1);

        }
        
    }
    private void disableCollider()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
    private void disableMesh()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
