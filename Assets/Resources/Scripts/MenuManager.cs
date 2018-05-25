using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.instance.InstructionsLevel1.enabled = false;
        UIManager.instance.InstructionsLevel2.enabled = false;
        UIManager.instance.InstructionsLevel3.enabled = false;
        UIManager.instance.UIHealth.enabled = false;
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
        UIManager.instance.bullets.gameObject.SetActive(false);
    }
	
	
}
