using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public int Mobs = 7;
    public GameObject PlayerUI;
    public GameObject GameWinUI;

    public Animator animator;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
            //Destroy(gameObject);
            Mobs -= 1;
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }
    
    public void Win()
    {
        if (Mobs <= 0)
        {
            PlayerUI.SetActive(false);
            GameWinUI.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<Weapon>().enabled = false;
        }
    }
  
    void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<Enemy>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

    }
}
