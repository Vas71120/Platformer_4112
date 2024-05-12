using System;
using UnityEngine;

[Serializable]
public struct AttackInfo
{
    [SerializeField] public DamageInfo damage;
    [SerializeField, Min(0f)] public float range;
    [SerializeField, Min(0f)] public float preparation;
    [SerializeField, Min(0f)] public float duration;
    [SerializeField, Min(0f)] public float cooldown;
}
