using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBullet : BaseBullet {


    // Use this for initialization
    public override void Setup()
    {
        type = BulletType.Fast;
        damage = DamageType.Low;
        velocity = 5000f;
    }

}
