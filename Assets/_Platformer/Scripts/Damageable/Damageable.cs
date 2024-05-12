using System;

[Serializable]
public struct DamageInfo
{
    public float damage;
}

public interface IDamageable
{
    public float TakeDamage(DamageInfo damageInfo);
}
