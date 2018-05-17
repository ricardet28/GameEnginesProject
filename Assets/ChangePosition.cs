using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour {
    private float timeToTeleport;
    private float currentTime;
    public int indexCurrentPosition;
	// Use this for initialization
	void Start () {
        timeToTeleport = Random.Range(GestonesManager.instance.minTimeToTeleport, GestonesManager.instance.maxTimeToTeleport);
	}

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToTeleport)
        {
            ChangeGemstonePosition();
            currentTime = 0f;
            timeToTeleport = Random.Range(GestonesManager.instance.minTimeToTeleport, GestonesManager.instance.maxTimeToTeleport);
        }
    }

    private void ChangeGemstonePosition()
    {
        int index = Random.Range(0, GestonesManager.instance.GemstonesPositions.Length);
        while (CheckIfBusy(index))
        {
            index = Random.Range(0, GestonesManager.instance.GemstonesPositions.Length);
        }

        this.transform.position = GestonesManager.instance.GemstonesPositions[index].position;
        
    }

    private bool CheckIfBusy(int index)
    {
        int num = GestonesManager.instance.Gemstones.Length;
        for (int i = 0; i<num; i++)
        {
            if (GestonesManager.instance.Gemstones[i].gameObject != this.gameObject 
                && GestonesManager.instance.Gemstones[i].GetComponent<ChangePosition>().indexCurrentPosition == index)
            {
                return true;
            }
            
            
        }
        return false;
    }
}
