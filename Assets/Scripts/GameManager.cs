using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private LevelManager _currentLevel;
    private int[] scenesIndexArray = new int[] { 0, 1, 2, 3 };

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        
        SceneManager.LoadScene(1);
        _currentLevel = GameObject.FindObjectOfType<LevelManager>();

    }

    private void Update()
    {


        _currentLevel = GameObject.FindObjectOfType<LevelManager>();
        if (LevelCompleted())
        {
            SceneManager.LoadScene(2);
        }
    }

    private bool LevelCompleted()
    {
        return _currentLevel.levelCompleted;
    }

    private void SetCurrentLevel()
    {
        _currentLevel = GameObject.FindObjectOfType<LevelManager>();
    }
}
