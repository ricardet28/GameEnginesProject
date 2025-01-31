﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance = null;
    public AudioSource _audio;
    private GameManager.Scenes _currentScene;

    public AudioClip[] songs;

    public static int winner;
    public static bool imageChanged;


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
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
    
        _currentScene = GameManager.instance.activeScene;

        Debug.Log((int)_currentScene);

        switch (_currentScene)
        {
            case GameManager.Scenes.Menu:
                _audio.clip = songs[0];
                if (!_audio.isPlaying)
                {
                    _audio.Stop();
                    _audio.Play();
                }

                break;
            case GameManager.Scenes.Corridor:

                if (_audio.clip != songs[1])
                {
                    _audio.Stop();
                    _audio.clip = songs[1];
                    _audio.Play();
                }

                break;
        }
    }

    public void StopMusic()
    {
        _audio.enabled = false;
    }

    public void PlayMusic()
    {
        _audio.enabled = true;
        switch (_currentScene)
        {
           
            case GameManager.Scenes.Tutorial0:  
                _audio.Stop();
                _audio.clip = songs[2];
                _audio.Play();         
                break;

            case GameManager.Scenes.Tutorial1:
                _audio.Stop();
                _audio.clip = songs[3];
                _audio.Play();
                break;

            case GameManager.Scenes.Tutorial2:
                _audio.Stop();
                _audio.clip = songs[4];
                _audio.Play();
                break;
        }
    }


}
