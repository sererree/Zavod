using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float Speed = 50f;
    public float lifeTime = 60;
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, 5);
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        Invoke("OnCollisionEnter", lifeTime);
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
            enemyHealth.value -= damage;
            if(enemyHealth.value <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        }
        
    }
}
