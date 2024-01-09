using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    public event Action HealthChanged;
    
    public int Health => _health;
    
    private int _startHealth;
    private int _minHealth;

    private void Start()
    {
        _startHealth = _health;
        _minHealth = 0;
    }

    public void Heal(int heal)
    {
        if(_health <= _startHealth - heal)
            _health += heal;
        HealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (_minHealth > _health - damage)
            _health = 0;
        else
            _health -= damage;
        HealthChanged?.Invoke();
    }
}