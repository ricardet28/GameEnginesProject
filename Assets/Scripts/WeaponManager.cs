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
        if(instance == null)
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

    void Start()
    {
        weapons = GameObject.FindObjectsOfType<BaseWeapon>();

        activeWeaponIndex = 0;

        foreach (BaseWeapon w in weapons)
        {
            w.Setup();
            w.gameObject.SetActive(false);
        }

        Debug.Log(weapons.Length);
        weapons[activeWeaponIndex].gameObject.SetActive(true);

        activeBulletIndex = 2;
        foreach (BaseBullet b in bullets)
        {
            b.Setup();
        }

    }

    void ChangeTypeOfBullet()
    {
        activeBulletIndex++;
        if (activeBulletIndex + 1 > bullets.Length) activeBulletIndex = 0;
    }

    void ChangeTypeOfWeapon()
    {
        weapons[activeWeaponIndex].gameObject.SetActive(false);
        activeWeaponIndex++;
        if (activeWeaponIndex + 1 > weapons.Length) activeWeaponIndex = 0;
        weapons[activeWeaponIndex].gameObject.SetActive(true);

    }

    void CheckChangeOfBullet()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeTypeOfBullet();
        }
    }

    void CheckChangeOfWeapon()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeTypeOfWeapon();
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
