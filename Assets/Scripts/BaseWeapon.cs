using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseWeapon : MonoBehaviour {

    public WeaponManager weaponManager;

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

    void Start()
    {
        weaponManager = GameObject.FindObjectOfType<WeaponManager>();
    }

    void Fire()
    {
        GameObject gO = Instantiate(weaponManager.bullets[weaponManager.activeBulletIndex].gameObject, shootPoint.position, shootPoint.rotation);

        Rigidbody rBodyBullet = gO.GetComponent<Rigidbody>();
        
        rBodyBullet.AddForce(weaponManager.bullets[weaponManager.activeBulletIndex].velocity * shootPoint.transform.forward);

        anim.CrossFadeInFixedTime("Fire", fireRate);

        fireTimer = 0;
        currentBullets--;
    }

    protected void CheckFire()
    {

        Debug.DrawRay(shootPoint.position, shootPoint.transform.forward, Color.red);

        if (Input.GetButton("Fire1") && fireTimer > fireRate && currentBullets > 0 && !IsReloading())
        {
            Fire();
        }

        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }


    protected void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentBullets < bulletsPerMag)
        {
            Reload();
        }
    }

    protected void Reload()
    {
        if (bulletsLeft <= 0) return;

        DoReload();

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
    }

    protected bool IsReloading()
    {
        return info.IsName("Reload");
    }

    protected void DoReload()
    {
        if (IsReloading()) return;

        anim.CrossFadeInFixedTime("Reload", fireRate);
    }

    void FixedUpdate()
    {
        CheckReload();
        CheckFire();
    }

    void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
    }
}
