using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float Speed = 50f;
    public float lifeTime = 60;
    public float damage = 10f;
    public AudioSource shoot;
   
   


    void Start()
    {
        Destroy(gameObject, 5);
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        shoot.Play();
    }


    void OnCollisionEnter(Collision collision)
    {
        
        DamageEnemy(collision);
        DestroyBullet();

    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
  
   
   
    private void DamageEnemy(Collision collision)
    {

        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }

    }
     
}

