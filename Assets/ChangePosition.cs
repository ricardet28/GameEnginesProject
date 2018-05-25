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
        currentTime = 0f;
        timeToTeleport = Random.Range(GestonesManager.instance.minTimeToTeleport, GestonesManager.instance.maxTimeToTeleport);

    }

    private bool IsBusy(int index)
    {
        int num = GestonesManager.instance.Gemstones.Length;
        for (int i = 0; i<num; i++)
        {
            if (this.gameObject != GestonesManager.instance.Gemstones[i].gameObject
                && index == GestonesManager.instance.Gemstones[i].GetComponent<ChangePosition>().indexCurrentPosition)
            {
                return true;
            }
        }
        return false;
    }
}
