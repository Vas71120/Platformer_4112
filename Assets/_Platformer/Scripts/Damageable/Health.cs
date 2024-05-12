using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField, Min(0f)] private float max = 100f;
    [SerializeField, Min(0f)] private float current = 100f;

    private float Current
    {
        get => current;
        set => current = Mathf.Clamp(value, 0f, max);
    }

    public float Max => max;

    public float Ratio => current / max;

    public bool IsAlive => current > 0f;

    public event Action<IHealth, DamageInfo> onDamage;
    public event Action<IHealth, DamageInfo> onDeath;

    private void OnValidate()
    {
        Current = Current;
    }

    public bool CanBeDamaged(DamageInfo damageInfo)
    {
        return IsAlive;
    }

    public float TakeDamage(DamageInfo damageInfo)
    {
        if (damageInfo.damage < 0f) return 0f;
        if (!CanBeDamaged(damageInfo)) return 0f;

        var oldCurrent = Current;

        Current -= damageInfo.damage;

        onDamage?.Invoke(this, damageInfo);
        if (!IsAlive) onDeath?.Invoke(this, damageInfo);

        return Mathf.Abs(oldCurrent - Current);
    }
}