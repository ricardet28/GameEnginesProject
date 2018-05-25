using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLoader : MonoBehaviour {

	public void onLoadLoader()
    {
        SceneManager.LoadScene((int)GameManager.Scenes.Corridor);
    }
}
