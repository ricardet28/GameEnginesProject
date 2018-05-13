using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorManager : MonoBehaviour
{

    public Transform spawnPoint;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    private PlayerHealth _playerHealth;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }
    // Use this for initialization
    void Start()
    {
        SetUpUI();
        OnGoingToCorridor();
        if(GameManager.instance.scenesState[(int)GameManager.Scenes.Tutorial1] == true)
        {
            panel1.SetActive(false);
        }
    }

    void OnGoingToCorridor()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;       
    }

    void SetUpUI()
    {
        UIManager.instance.healthPoints = _playerHealth.initHealthPoints;
        UIManager.instance.healthBar.value = _playerHealth.initHealthPoints;
        UIManager.instance.UIPoints.enabled = false;
        UIManager.instance.UIPointsToReach.enabled = false;
        UIManager.instance.UITime.enabled = false;
        UIManager.instance.healthBar.gameObject.SetActive(false);
        Color _newColor = UIManager.instance.UIDamageImage.color;
        _newColor.a = 0;
        UIManager.instance.UIDamageImage.color = _newColor;
    }

}
	
	
