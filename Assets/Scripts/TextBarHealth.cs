using TMPro;
using UnityEngine;

public class TextBarHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] TMP_Text _currentHealth;

    private void Start()
    {
        _currentHealth.text = _player.Health.ToString();
    }

    private void OnEnable()
    {
        _player.HealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= DisplayHealth;
    }

    private void DisplayHealth()
    {
        _currentHealth.text = _player.Health.ToString();
    }
}