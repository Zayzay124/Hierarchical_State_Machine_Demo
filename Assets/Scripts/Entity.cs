using System;
using System.Linq.Expressions;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int currentHealth;

    public int maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
