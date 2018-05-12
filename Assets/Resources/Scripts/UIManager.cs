using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text UITime;
    public Text UIPoints;
    public int initHealthPoints;
    public int healthPoints;
    public Text UIPointsToReach;
    public Text UIHealth;
    public Slider healthBar;
    public Color fullHealth;
    public Color minHealth;
    private Color targetColor;
    public Image fillImage;

    [SerializeField]private float decreaseHealthBarSpeed = 0.1f;

    public Image UISlowBullets3;
    public Image UISlowBullets2;
    public Image UISlowBullets1;

    public Image UIFastBullets3;
    public Image UIFastBullets2;
    public Image UIFastBullets1;

    public Image UIMediumBullets3;
    public Image UIMediumBullets2;
    public Image UIMediumBullets1;


    public static UIManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        
    }

    public IEnumerator decreaseHealthBar()
    {
        WaitForEndOfFrame waiter = new WaitForEndOfFrame();
        float lerpValue = 0;
        while (lerpValue < 1f)
        {
            lerpValue += Time.deltaTime * decreaseHealthBarSpeed;
            healthBar.value = Mathf.Lerp(healthBar.value, healthPoints, lerpValue);
            fillImage.color = Color.Lerp(fillImage.color, targetColor, lerpValue);
            yield return waiter;
        }
        lerpValue = 0;

        Debug.Log("exit corroutine");
    }

    public void setTargetColorHealthBar()
    {
        float lerpValue = (float)healthPoints / (float)initHealthPoints;
        targetColor = Color.Lerp(minHealth, fullHealth, lerpValue);
    }

     public void checkColorUIBullets(int activeBulletIndex, int currentBullets)
     {
         Debug.Log(activeBulletIndex);
         if(activeBulletIndex == (int)BaseBullet.BulletType.Fast)
         {
             if(currentBullets == 3)
            {
                UIFastBullets3.enabled = true;
                UIFastBullets2.enabled = true;
                UIFastBullets1.enabled = true;
            }

            if (currentBullets == 2)
            {
                UIFastBullets3.enabled = false;
                UIFastBullets2.enabled = true;
                UIFastBullets1.enabled = true;
            }

            if (currentBullets == 1)
            {
                UIFastBullets3.enabled = false;
                UIFastBullets2.enabled = false;
                UIFastBullets1.enabled = true;
            }

            if (currentBullets == 0)
            {
                UIFastBullets3.enabled = false;
                UIFastBullets2.enabled = false;
                UIFastBullets1.enabled = false;
            }
        }

         if (activeBulletIndex == (int)BaseBullet.BulletType.Slow)
         {
            if (currentBullets == 3)
            {
                UISlowBullets3.enabled = true;
                UISlowBullets2.enabled = true;
                UISlowBullets1.enabled = true;
            }

            if (currentBullets == 2)
            {
                UISlowBullets3.enabled = false;
                UISlowBullets2.enabled = true;
                UISlowBullets1.enabled = true;
            }

            if (currentBullets == 1)
            {
               UISlowBullets3.enabled = false;
               UISlowBullets2.enabled = false;
                UISlowBullets1.enabled = true;
            }

            if (currentBullets == 0)
            {
                UISlowBullets3.enabled = false;
                UISlowBullets2.enabled = false;
                UISlowBullets1.enabled = false;
            }
        }                     

         if (activeBulletIndex == (int)BaseBullet.BulletType.Medium)
         {
            if (currentBullets == 3)
            {
                UIMediumBullets3.enabled = true;
                UIMediumBullets2.enabled = true;
                UIMediumBullets1.enabled = true;
            }

            if (currentBullets == 2)
            {
                UIMediumBullets3.enabled = false;
                UIMediumBullets2.enabled = true;
                UIMediumBullets1.enabled = true;
            }

            if (currentBullets == 1)
            {
                UIMediumBullets3.enabled = false;
                UIMediumBullets2.enabled = false;
                UIMediumBullets1.enabled = true;
            }

            if (currentBullets == 0)
            {
                UIMediumBullets3.enabled = false;
                UIMediumBullets2.enabled = false;
                UIMediumBullets1.enabled = false;
            }
        }

     }                            
}

