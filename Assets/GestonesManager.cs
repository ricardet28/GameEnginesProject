using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GestonesManager : MonoBehaviour {

    public static GestonesManager instance = null;

    public Transform[] GemstonesPositions;
    public GameObject[] Gemstones;

    public float minTimeToTeleport;
    public float maxTimeToTeleport;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SpawnGemstones();
        while (PositionsRepeated())
        {
            SpawnGemstones();
        }

        Debug.Log("Gemstones spawned!");
    }

  
    private void SpawnGemstones()
    {
        for (int i = 0; i < Gemstones.Length; i++)
        {
            int indexRandom = Random.Range(0, GemstonesPositions.Length);
            
            Gemstones[i].transform.position = GemstonesPositions[indexRandom].position;
            Gemstones[i].transform.parent = GemstonesPositions[indexRandom];
            Gemstones[i].GetComponent<ChangePosition>().indexCurrentPosition = indexRandom;
        }
    }
    
    private bool PositionsRepeated()
    {
       
        for (int i = 0; i < Gemstones.Length; i++)
        {
            for (int j = 0; j < Gemstones.Length; j++)
            {
                if (Gemstones[i].gameObject != Gemstones[j].gameObject && Gemstones[i].GetComponent<ChangePosition>().indexCurrentPosition == Gemstones[j].GetComponent<ChangePosition>().indexCurrentPosition)
                {
                    return true;
                }
            }
            
        }
        return false;
    }
}
