using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int _currentHealth;

    public int maxHealth;

    public int CurrentHealth { get { return _currentHealth; } }
    public int MaxHealth { get { return maxHealth; } }


    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(this.name + "taken damage");
        _currentHealth -= amount;
        //tell state machine to use attack data to calculate knockback
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(this.name + " Dead");
    }
}
