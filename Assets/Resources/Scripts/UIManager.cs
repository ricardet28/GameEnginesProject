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
    [SerializeField]private float flashImageTime = 0.3f;
    private int _activeBullet;

    public Image UISlowBulletIcon;
    public Image UISlowBullets3;
    public Image UISlowBullets2;
    public Image UISlowBullets1;

    public Image UIFastBulletIcon;
    public Image UIFastBullets3;
    public Image UIFastBullets2;
    public Image UIFastBullets1;

    public Image UIMediumBulletIcon;
    public Image UIMediumBullets3;
    public Image UIMediumBullets2;
    public Image UIMediumBullets1;

    public Image UIHitImage;
    public Image UIDamageImage;

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
    
    public void ChangeDamageImageAlpha()
    {
        float lerpValue = (float)healthPoints / (float)initHealthPoints;
        Color imageColor = new Color(1, 0, 0, Mathf.Lerp(1, 0, lerpValue));
        UIDamageImage.color = imageColor;
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
    }

    public IEnumerator HitFlash()
    {
        UIHitImage.gameObject.SetActive(true);
        float currentTime = 0;
        while (currentTime <= flashImageTime)
        {
            currentTime += Time.deltaTime;
            yield return null;

        }
        UIHitImage.gameObject.SetActive(false);
    }

    public void setTargetColorHealthBar()
    {
        float lerpValue = (float)healthPoints / (float)initHealthPoints;
        targetColor = Color.Lerp(minHealth, fullHealth, lerpValue);
    }

     public void checkColorUIBullets(int activeBulletIndex, int currentBullets)
     {
        _activeBullet = activeBulletIndex;
         if(activeBulletIndex == (int)BaseBullet.BulletType.Fast)
         {
            UIFastBulletIcon.enabled = true;
            UIMediumBulletIcon.enabled = false;
            UISlowBulletIcon.enabled = false;
            if (currentBullets == 3)
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
            UIFastBulletIcon.enabled = false;
            UIMediumBulletIcon.enabled = false;
            UISlowBulletIcon.enabled = true;
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
            UIFastBulletIcon.enabled = false;
            UIMediumBulletIcon.enabled = true;
            UISlowBulletIcon.enabled = false;
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

