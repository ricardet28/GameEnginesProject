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

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToTeleport)
        {
            ChangeGemstonePosition();
            
        }
    }

    private void ChangeGemstonePosition()
    {
        int index = Random.Range(0, GestonesManager.instance.GemstonesPositions.Length);
        while (IsBusy(index))
        {
            index = Random.Range(0, GestonesManager.instance.GemstonesPositions.Length);
        }

        this.transform.position = GestonesManager.instance.GemstonesPositions[index].position;
        this.transform.parent = GestonesManager.instance.GemstonesPositions[index];
        currentTime = 0f;
        timeToTeleport = Random.Range(GestonesManager.instance.minTimeToTeleport, GestonesManager.instance.maxTimeToTeleport);
    }

    private bool IsBusy(int index)
    {    
        if (GestonesManager.instance.GemstonesPositions[index].childCount > 0)
        {
            return true;
        }
        return false;
        
    }
}
