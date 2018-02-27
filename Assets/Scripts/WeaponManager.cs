using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    
    public BaseWeapon weapon;

    public int activeBulletIndex;

    public BaseBullet[] bullets;

    void Start()
    {
        weapon.Setup();

        activeBulletIndex = 0;
        foreach (BaseBullet b in bullets)
        {
            b.Setup();
        }

    }

    
}
