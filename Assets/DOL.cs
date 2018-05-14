using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DOL : MonoBehaviour {

    private static DOL instance = null; 
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

    }
}
