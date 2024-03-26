using UnityEngine;
public class BananaBomb : MonoBehaviour
{
    //Задай параметры радиуса, урона, таймера и скорости запуска
    public AudioSource CollisionSound;
    public GameObject ExplosionEffect;
    public float Radius = 5;
    public float Damage = 80;
    public float Timer = 3;
    public float LaunchSpeed = 20;

    

    void Start()
    {
        //Ставим таймер на вызов взрыва
        Invoke("Explode", 3);
        //Запускаем банановую бомбу вперед
        GetComponent<Rigidbody>().velocity = transform.forward * LaunchSpeed;
    }

    void Explode()
    {
        //Находим все коллайдеры в радиусе взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            //Предполагаем, что коллайдер - это враг
            EnemyHealth enemyHealth = colliders[i].GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.value -= Damage;
                if (enemyHealth.value <= 0)
                {
                    Destroy(enemyHealth.gameObject);
                }
                
            }

        }
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionSound.pitch = Random.Range(0.7f, 1.3f);
        CollisionSound.Play();
    }
    
}