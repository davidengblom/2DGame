using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string unitName;
    public int maxHealth = 100;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //play hit animation

        if(currentHealth <= 0)
        {
            //Kill the enemy
        }
    }

    private void Die()
    {
        //Death animation

        //Disable enemy
    }
}
