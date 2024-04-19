using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event EventHandler OnDead;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    [SerializeField] int startingHealth = 5;

    [SerializeField]private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        OnDamaged?.Invoke(this, EventArgs.Empty);


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        OnDead?.Invoke(this, EventArgs.Empty);
    }

    public float GetHealthNormalized()
    {
        return (float)currentHealth / startingHealth;
    }

    public void SetHealthToMax()
    {
        currentHealth = startingHealth;
        OnHealed?.Invoke(this, EventArgs.Empty);
    }

}
