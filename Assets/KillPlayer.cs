using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colision con " + collision.gameObject.tag);
            PlayerHealth _playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            _playerHealth.getDamage(_playerHealth.healthPoints);
        }
    }
}
