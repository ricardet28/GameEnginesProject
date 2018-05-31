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
    public AudioSource destroyItem;
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
            Destroy(this.gameObject);
        }
    }


    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<FastBullet>() != null || c.gameObject.GetComponent<MediumBullet>() != null || c.gameObject.GetComponent<SlowBullet>() != null)
        {

            Debug.Log(this.gameObject.name);
            destroyItem.Play();
            Debug.Log(destroyItem.name);
            TakeDamage((int)c.gameObject.GetComponent<BaseBullet>().damage);
            levelManager.AddPoints(pointsWhenDestroyed);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (this.gameObject.transform.childCount == 0)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<Light>().enabled = false;
                this.gameObject.GetComponent<VolumetricLight>().enabled = false;
            }
            else
            {
                this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
               
            }
            
                
            Destroy(this.gameObject,0.5f);
        }
        if (c.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject, 0.5f);
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
