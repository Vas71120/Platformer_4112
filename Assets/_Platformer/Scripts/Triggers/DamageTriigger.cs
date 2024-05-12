using UnityEngine;

public class DamageTriigger : Trigger
{
    [Header("Damage")]
    [SerializeField] private DamageInfo damage;

    public override void Activate(Collider2D other)
    {
        var damageable = other.GetComponent<IDamageable>();
        damageable?.TakeDamage(damage);
    }
}
