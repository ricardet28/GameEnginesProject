using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : BaseBullet {

    public override void Setup()
    {
        type = BulletType.Slow;
        damage = DamageType.High;
        velocity = 1000f;
    }
}
