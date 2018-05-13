using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorManager : MonoBehaviour
{

    public Transform spawnPoint;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    // Use this for initialization
    void Start()
    {

        OnGoingToCorridor();
        if(GameManager.instance.scenesState[(int)GameManager.Scenes.Tutorial1] == true)
        {
            panel1.SetActive(false);
        }
    }

    void OnGoingToCorridor()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;       
    }
}
	
	
