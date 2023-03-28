using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animatorEnemy;
    public int maxHealht = 100;
    int curretHealht;


    void Start()
    {
        curretHealht = maxHealht;
    }

    public void TakeDamage(int damage)
    {
        curretHealht -=damage;
        
       animatorEnemy.SetTrigger("Hurt");
        
        if (curretHealht <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Necro dead");
       animatorEnemy.SetBool("IsDead", true);
       
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
