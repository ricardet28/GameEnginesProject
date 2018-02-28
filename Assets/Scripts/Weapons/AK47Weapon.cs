using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Weapon : BaseWeapon {

    public override void Setup()
    {
        currentBullets = 20;

        range = 100f;

        bulletsPerMag = 20;
        bulletsLeft = 200;
        fireRate = 0.1f;

        anim = GetComponentInParent<Animator>();
    }

}
