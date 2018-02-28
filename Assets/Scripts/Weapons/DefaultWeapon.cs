using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : BaseWeapon {

    public override void Setup()
    {
        currentBullets = 3;

        range = 100f;

        bulletsPerMag = 3;
        bulletsLeft = 200;
        fireRate = 0.5f;

        anim = GetComponentInParent<Animator>();
    }

}
