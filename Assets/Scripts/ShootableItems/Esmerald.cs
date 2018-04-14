using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esmerald : ShootableItem {

    public override void Setup()
    {
        lifePoints = 100;
        pointsWhenDestroyed = 150;
    }
}
