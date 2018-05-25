using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour {

    //enum Scenes { Loader = 0, Menu = 1, Corridor = 2, Tutorial0 = 3, Tutorial1 = 4 };

    public GameManager.Scenes nextScene;
    public float timeBetweenChangeScenes = 3f;

    private bool menuButtonPressed;
    private bool corridorButtonPressed;

    
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
                StartCoroutine(ShowLevelCompletedInfo());
                
            }
        }
    }

    private IEnumerator ShowLevelCompletedInfo()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        LevelManager.instance.DisablePlayerControls();
        AIManager.instance.DisableAI();
        UIManager.instance.UIPoints.enabled = false;
        UIManager.instance.UIPointsToReach.enabled = false;
        UIManager.instance.InfoImage.enabled = true;
        UIManager.instance.InfoText.enabled = true;
        UIManager.instance.InfoText.text = "level completed";
        int timeSpent = (int)LevelManager.instance.maxTimeToComplete - (int)LevelManager.instance.currentTime;
        UIManager.instance.TimeSpentText.enabled = true;
        UIManager.instance.TimeSpentText.text = "it took you " + timeSpent + " seconds";
        UIManager.instance.corridorButton.gameObject.SetActive(true);
        UIManager.instance.menuButton.gameObject.SetActive(true);
        Button _menuButton = UIManager.instance.menuButton;
        Button _corridorButton = UIManager.instance.corridorButton;
       
        
        _menuButton.onClick.AddListener(ClickMenuButton);
        _corridorButton.onClick.AddListener(ClickCorridorButton);

        while (!corridorButtonPressed && !menuButtonPressed)
        {
            yield return null;
        }
        corridorButtonPressed = false;
        menuButtonPressed = false;
        LevelManager.instance.EnablePlayerControls();
        GameManager.instance.ChangeLevel(nextScene);
    }

    private void ClickMenuButton()
    {
        menuButtonPressed = true;
    }

    private void ClickCorridorButton()
    {
        corridorButtonPressed = true;
    }
}
