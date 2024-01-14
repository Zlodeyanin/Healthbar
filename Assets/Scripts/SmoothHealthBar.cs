using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _speed;
    
    private Slider _healthBar;
    private Coroutine _changeHealth;
    private float _currentHealth;
    
    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _currentHealth = _player.Health / _player.MaxHealth;
        _healthBar.value = _currentHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeBarValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeBarValue;
    }

    private void ChangeBarValue()
    {
        if (_changeHealth == null)
        {
            _changeHealth = StartCoroutine(SmoothChangeValue());
        }

        if (_player == null)
        {
            StopCoroutine(_changeHealth);
        }
    }

    private IEnumerator SmoothChangeValue()
    {
        while (true)
        {
            _currentHealth = _player.Health / _player.MaxHealth;
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentHealth,_speed * Time.deltaTime);
            yield return null;
        } 
    }
}