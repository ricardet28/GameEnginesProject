using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
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
        MusicManager.instance.PlayMusic();
        SetUpUI();
        OnGoingToCorridor();
        if(GameManager.instance.scenesState[(int)GameManager.Scenes.Tutorial1] == true)
        {
            panel1.SetActive(false);
        }
        if (GameManager.instance.scenesState[(int)GameManager.Scenes.Tutorial2] == true)
        {
            panel2.SetActive(false);
        }
    }

    void OnGoingToCorridor()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnPoint.position;       
    }

    void SetUpUI()
    {
        
        UIManager.instance.InstructionsLevel1.enabled = false;
        UIManager.instance.InstructionsLevel2.enabled = false;
        UIManager.instance.InstructionsLevel3.enabled = false;
        UIManager.instance.healthPoints = _playerHealth.initHealthPoints;
        UIManager.instance.UIHealth.enabled = false;
        UIManager.instance.healthBar.value = _playerHealth.initHealthPoints;
        UIManager.instance.UIPoints.enabled = false;
        UIManager.instance.UIPointsToReach.enabled = false;
        UIManager.instance.UITime.enabled = false;
        UIManager.instance.healthBar.gameObject.SetActive(false);
        Color _newColor = UIManager.instance.UIDamageImage.color;
        _newColor.a = 0;
        UIManager.instance.UIDamageImage.color = _newColor;
        UIManager.instance.InfoImage.enabled = false;
        UIManager.instance.InfoText.enabled = false;
        UIManager.instance.SubInfoText.enabled = false;
        UIManager.instance.TimeSpentText.enabled = false;
        UIManager.instance.corridorButton.gameObject.SetActive(false);
        UIManager.instance.menuButton.gameObject.SetActive(false);
        UIManager.instance.instructionsButton.gameObject.SetActive(false);
        UIManager.instance.instructionsImage.enabled = false;
        UIManager.instance.backLevelButton.gameObject.SetActive(false);
        UIManager.instance.bullets.gameObject.SetActive(true);


    }

}
	
	
