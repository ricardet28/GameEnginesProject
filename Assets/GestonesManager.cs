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
        CheckSamePosition();
        Debug.Log("Gemstones spawned!");
    }

  
    private void SpawnGemstones()
    {
        for (int i = 0; i < Gemstones.Length; i++)
        {
            int indexRandom = Random.Range(0, GemstonesPositions.Length);
            
            Gemstones[i].transform.position = GemstonesPositions[indexRandom].position;
            Gemstones[i].GetComponent<ChangePosition>().indexCurrentPosition = indexRandom;
        }
    }
    
    private void CheckSamePosition()
    {
        int[] indexsUsed = new int[Gemstones.Length];
        int j = 0;
        for (int i = 0; i<Gemstones.Length; i++)
        {
            int indexOfCurrentGemstone = Gemstones[i].GetComponent<ChangePosition>().indexCurrentPosition;
            if (indexsUsed.Contains(indexOfCurrentGemstone))
            {
                SpawnGemstones();
            }
            else
            {
                indexsUsed[j] = indexOfCurrentGemstone;
                j++;
            }
        }
    }
}
