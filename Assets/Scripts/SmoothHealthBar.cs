using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _speed;
    
    private Slider _healthBar;
    private bool _healthChanged;
    private Coroutine _changeHealth;
    
    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = _player.Health;
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeBarValue;
        _healthChanged = true;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeBarValue;
        _healthChanged = false;
    }

    private void ChangeBarValue()
    {
        if (_healthChanged)
        {
            _changeHealth = StartCoroutine(SmoothChangeValue());
        }
        else
        {
            StopCoroutine(_changeHealth);
        }
    }

    private IEnumerator SmoothChangeValue()
    {
        while (_healthBar.value != _player.Health)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _player.Health,_speed * Time.deltaTime);
            yield return null;
        } 
    }
}