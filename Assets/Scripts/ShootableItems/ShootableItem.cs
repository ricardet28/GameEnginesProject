using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ShootableItem : MonoBehaviour {

    protected int lifePoints;
    protected int pointsWhenDestroyed;

    LevelManager levelManager;

    public abstract void Setup();

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Setup();
    }

    public void TakeDamage(int d)
    {
        lifePoints -= d;
        if (lifePoints - d <= 0)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        levelManager.AddPoints(pointsWhenDestroyed);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<BaseBullet>() != null)
        {
            TakeDamage((int)c.gameObject.GetComponent<BaseBullet>().damage);
        }
    }
}
