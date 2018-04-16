using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public static WeaponManager instance = null;

    private BaseWeapon [] weapons;

    public int activeBulletIndex;
    public int activeWeaponIndex;

    public BaseBullet[] bullets;

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

    void Start()
    {
        weapons = GameObject.FindObjectsOfType<BaseWeapon>();

        activeWeaponIndex = 1;

        foreach (BaseWeapon w in weapons)
        {
            w.Setup();
            w.gameObject.SetActive(false);
        }

        //Debug.Log(weapons.Length);
        weapons[activeWeaponIndex].gameObject.SetActive(true);

        activeBulletIndex = (int)BaseBullet.BulletType.Slow;
        foreach (BaseBullet b in bullets)
        {
            b.Setup();
        }

        UIManager.instance.checkColorUIBullets(activeBulletIndex, weapons[activeWeaponIndex].currentBullets);



    }

    void ChangeTypeOfBulletDownwards()
    {
        activeBulletIndex++;
        if (activeBulletIndex + 1 > bullets.Length) activeBulletIndex = (int)BaseBullet.BulletType.Fast;
        weapons[activeWeaponIndex].Reload();
    }

    void ChangeTypeOfBulletUpwards()
    {
        activeBulletIndex--;
        if (activeBulletIndex < 0) activeBulletIndex = (int)BaseBullet.BulletType.Slow;
        weapons[activeWeaponIndex].Reload();
    }

    void ChangeTypeOfWeapon(int n)
    {
        weapons[activeWeaponIndex].gameObject.SetActive(false);
        activeWeaponIndex = n;
        weapons[activeWeaponIndex].gameObject.SetActive(true);

    }

    void CheckChangeOfBullet()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeTypeOfBulletDownwards();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeTypeOfBulletUpwards();
        }
    }

    void CheckChangeOfWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && activeWeaponIndex != 0)
        {
            ChangeTypeOfWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && activeWeaponIndex != 1)
        {
            ChangeTypeOfWeapon(1);
        }
    }

    void CheckFire()
    {
        if (Input.GetButton("Fire1") && weapons[activeWeaponIndex].fireTimer > weapons[activeWeaponIndex].fireRate && weapons[activeWeaponIndex].currentBullets > 0 && !weapons[activeWeaponIndex].IsReloading())
        {
            weapons[activeWeaponIndex].Fire();
        }

        if (weapons[activeWeaponIndex].fireTimer < weapons[activeWeaponIndex].fireRate)
        {
            weapons[activeWeaponIndex].fireTimer += Time.deltaTime;
        }
    }

    void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && weapons[activeWeaponIndex].currentBullets < weapons[activeWeaponIndex].bulletsPerMag)
        {
            weapons[activeWeaponIndex].Reload();
        }
    }

    void FixedUpdate()
    {
        CheckFire();
        CheckReload();
    }

    void Update()
    {
        CheckChangeOfBullet();
        CheckChangeOfWeapon();
    }
}
