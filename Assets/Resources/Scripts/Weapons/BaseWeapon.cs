using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseWeapon : MonoBehaviour {


    protected Animator anim;

    public float range;

    public int bulletsPerMag;
    public int bulletsLeft;
    public int currentBullets;

    public Transform shootPoint;

    public float fireRate;
    public float fireTimer;

    public bool isReloading;
    public AnimatorStateInfo info;

    public abstract void Setup();

    public AudioSource audioSourceGun;
    public AudioClip shootGun;
    public AudioClip reloadGun;

    void Start()
    {
        if(WeaponManager.instance == null)
        {
            Debug.LogError("Falta el WeaponManager, añade el prefab");
        }
    }

    public void Fire()
    {

        GameObject bullet = Instantiate(WeaponManager.instance.bullets[WeaponManager.instance.activeBulletIndex].gameObject, shootPoint.position, shootPoint.rotation);

        Rigidbody rBodyBullet = bullet.GetComponent<Rigidbody>();
        
        rBodyBullet.AddForce(WeaponManager.instance.bullets[WeaponManager.instance.activeBulletIndex].velocity * shootPoint.transform.forward);

        audioSourceGun.clip = shootGun;
        audioSourceGun.Play();

        anim.CrossFadeInFixedTime("Fire", 0.1f);

        fireTimer = 0;
        currentBullets--;

        UIManager.instance.checkColorUIBullets(WeaponManager.instance.activeBulletIndex, currentBullets);

    }



    public void Reload()
    {
        if (bulletsLeft <= 0) return;

        audioSourceGun.clip = reloadGun;
        audioSourceGun.Play();

        DoReload();

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;

        UIManager.instance.checkColorUIBullets(WeaponManager.instance.activeBulletIndex, currentBullets);
    }

    public bool IsReloading()
    {
        return info.IsName("Reload");
    }

    protected void DoReload()
    {
        if (IsReloading()) return;

        anim.CrossFadeInFixedTime("Reload", fireRate);
    }

    void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
    }

    public void resetAmmo()
    {
        currentBullets = bulletsPerMag;
    }
}
