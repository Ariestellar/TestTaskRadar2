using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;
    public float Current { get => _current; }

    private float _current;

    public void Init(float currentHealth)
    {
        _current = currentHealth;
    }

    public void TakeDamage(float damage)
    {
      _current -= damage;            
      HealthChanged?.Invoke();
    }
}
