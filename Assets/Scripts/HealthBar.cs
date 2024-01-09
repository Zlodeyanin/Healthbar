using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    
    private Slider _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = _player.Health;
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
        _healthBar.value = _player.Health;
    }
}