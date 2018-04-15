using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    //enum Scenes { Loader = 0, Menu = 1, Corridor = 2, Tutorial0 = 3, Tutorial1 = 4 };

    public GameManager.Scenes nextScene;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex == (int)GameManager.Scenes.Corridor && GameManager.instance.scenesState[(int)nextScene])
            {
                GameManager.instance.ChangeLevel(nextScene);
            }
            else if (GameManager.instance._currentLevel.CheckLevelCompleted())//we are on a level completed door to exit corridor.
            {                               
                GameManager.instance.ChangeLevel(nextScene);
            }
        }
    }
}
