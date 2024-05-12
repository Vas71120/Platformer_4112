using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour, IDamageable
{
    [SerializeField] private Health health;
    [Space]
    [SerializeField] private UnityEvent onDeath;

    private IHealth _health;

    private void Awake()
    {
        _health = health;
    }

    private void OnEnable()
    {
        health.onDeath += Death;
    }

    private void OnDisable()
    {
        health.onDeath -= Death;
    }

    private void Death(IHealth component, DamageInfo damageInfo)
    {
        onDeath?.Invoke();
        gameObject.SetActive(false);
    }

    public float TakeDamage(DamageInfo damageInfo)
    {
        return _health.TakeDamage(damageInfo);
    }

    public void DecorateHealth(HealthDecorator decorator)
    {
        _health = decorator.Assign(_health) ?? _health;
    }
}