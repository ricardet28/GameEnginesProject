using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubi : ShootableItem {


    public override void Setup()
    {
        lifePoints = 200;
        pointsWhenDestroyed = 50;
    }
}
