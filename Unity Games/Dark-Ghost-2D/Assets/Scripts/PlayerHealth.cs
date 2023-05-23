using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthBar;

    private float _health;
    private float _minHealth = 0f;
    private float _maxHealth = 100.0f;
    private float _lerpSpeed;
    private float _lerpSpeedMode = 3.0f;

    private void Start()
    {
        _health = _maxHealth * 100;
    }

    private void Update()
    {
        if (_health > _maxHealth) _health = _maxHealth;
        _healthText.text = "Health " + _health;

        HealthBarFiller();

        _lerpSpeed = _lerpSpeedMode * Time.deltaTime;

        BarColorChanger();
    }

    private void HealthBarFiller()
    {
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _health / _maxHealth, _lerpSpeed);
    }

    public void Damage(float damagePoints)
    {
        if (_health > _minHealth)
        {
            _health -= damagePoints;
        }
    }

    public void Heal(float healPoints)
    {
        if (_health > _minHealth)
        {
            _health += healPoints;
        }
    }

    private void BarColorChanger()
    {
        Color _healthBarColor = Color.Lerp(Color.red, Color.green, (_health / _maxHealth));
        _healthBar.color = _healthBarColor;
    }
}