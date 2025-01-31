﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseBullet : MonoBehaviour {
    public enum BulletType { Fast = 0, Medium = 1, Slow = 2};
    public enum DamageType { Low = 50, Medium = 70, High = 100};

    public BulletType type;
    public DamageType damage;
    public float velocity;

    public abstract void Setup();

    void Start()
    {
        Destroy(gameObject, 3f);
    }

}
