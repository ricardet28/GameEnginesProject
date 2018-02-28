using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBullet : BaseBullet {
    public override void Setup()
    {
        type = BulletType.Medium;
        damage = DamageType.Medium;
        velocity = 2000f;
    }
}
