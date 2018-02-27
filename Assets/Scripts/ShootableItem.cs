using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ShootableItem : MonoBehaviour {

    public int lifePoints;
    public int pointsWhenDestroyed;

    public abstract void Setup();

    public void TakeDamage(int d)
    {
        lifePoints -= d;
        if (lifePoints - d < 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("ColisionFuera");
        Debug.Log(c.gameObject.GetType());
        if (c.GetType() == typeof(BaseBullet))
        {
            Debug.Log("Colision");
        }
    }
}
