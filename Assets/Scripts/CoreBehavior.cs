using UnityEngine;
using System;

public class CoreBehavior : MonoBehaviour, IDamageable
{
    public int health = 100;
    public event Action<int> OnCoreDamaged;
    public event Action OnCoreDestroyed;

    public void TakeDamage(int amount)
    {
        if (health <= 0) return;

        health -= amount;
        OnCoreDamaged?.Invoke(health);

        if (health <= 0)
        {
            OnCoreDestroyed?.Invoke();
            gameObject.SetActive(false); 
        }
    }
}