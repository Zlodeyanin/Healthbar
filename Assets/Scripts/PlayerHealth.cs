using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    public event Action HealthChanged;
    
    public float Health => _health;
    public float MaxHealth { get; private set; }

    private void Start()
    {
        MaxHealth = _health;
    }

    public void Heal(int heal)
    {
        _health += heal;
        _health = Mathf.Clamp(_health, 0, MaxHealth);
        HealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, MaxHealth);
        HealthChanged?.Invoke();
    }
}