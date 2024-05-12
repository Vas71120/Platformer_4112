using System;
using UnityEngine;

[Serializable]
public class FlatDamageDecorator : HealthDecorator
{
    [SerializeField] private float maxDamage = 20f;

    public override float TakeDamage(DamageInfo damageInfo)
    {
        damageInfo.damage = Mathf.Min(maxDamage, damageInfo.damage);
        return base.TakeDamage(damageInfo);
    }
}
