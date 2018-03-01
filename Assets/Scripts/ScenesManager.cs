﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    //enum Scenes { Loader = 0, Menu = 1, Corridor = 2, Tutorial0 = 3, Tutorial1 = 4 };

    public GameManager.Scenes nextScene;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("touching door");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("is player");
            if (SceneManager.GetActiveScene().buildIndex == (int)GameManager.Scenes.Corridor && GameManager.instance.scenesState[(int)nextScene])
            {
                GameManager.instance.ChangeLevel((int)nextScene);
            }
            else if (GameManager.instance._currentLevel.CheckLevelCompleted())//we are on a level completed door to exit corridor.
            {
                Debug.Log("entra");
                Debug.Log("going to scene in build" + (int)nextScene);
                GameManager.instance.scenesState[(int)nextScene] = true;
                GameManager.instance.ChangeLevel((int)nextScene);
            }
        }
    }

}
