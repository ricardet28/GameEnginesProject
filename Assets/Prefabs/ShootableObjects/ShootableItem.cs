using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ShootableItem : MonoBehaviour {

    private bool moveBullet = false;

    private Vector3 direction;
    private float velocity;

    protected int lifePoints;
    protected int pointsWhenDestroyed;

    LevelManager levelManager;

    public abstract void Setup();

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Setup();
    }

    private void Update()
    {
        if (moveBullet)
        {
            MoveBullet();
        }
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
        if (c.gameObject.GetComponent<FastBullet>() != null || c.gameObject.GetComponent<MediumBullet>() != null || c.gameObject.GetComponent<SlowBullet>() != null)
        {
            Debug.Log("esto existe");
            TakeDamage((int)c.gameObject.GetComponent<BaseBullet>().damage);
            Destroy(this.gameObject);
        }
        if (c.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveBullet(Vector3 direction, float velocity)
    {
        moveBullet = true;
        this.direction = direction;
        this.velocity = velocity;

    }
    private void MoveBullet()
    {
        this.transform.Translate(direction * velocity * Time.deltaTime);
        

    }
}
