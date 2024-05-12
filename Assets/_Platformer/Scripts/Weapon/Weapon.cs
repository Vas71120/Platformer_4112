using System;
using System.Collections;
using UnityEngine;

public enum MeleeState
{
    Idle,
    Preparation,
    Execution,
    Cooldown
}

public class Weapon : MonoBehaviour, IInputable
{
    [Header("Melee")]
    [SerializeField] private MeleeConfig config;

    [SerializeField] private Transform attackOffset;
    [SerializeField] private LayerMask layers;

    private bool _pendingAttack;
    private int _comboCounter;

    private MeleeState _state;

    public int ComboCounter 
    {
        get => _comboCounter;
        private set => _comboCounter = value % config.Attaks.Count;
    }

    public bool IsAttacking => _state != MeleeState.Idle;

    public event Action<Weapon> onAttack;

    public void Attack()
    {
        if (_pendingAttack) return;

        if (IsAttacking)
        {
            _pendingAttack = true;
            return;
        }

        StartCoroutine(PerformAttack());
    }

    private IEnumerator PerformAttack()
    {
        if (IsAttacking) yield break;

        var attack = config.Attaks[ComboCounter];

        _state = MeleeState.Preparation;
        onAttack?.Invoke(this);
        yield return new WaitForSeconds(attack.preparation);

        _state = MeleeState.Execution;
        StartCoroutine(DealDamage(attack));
        yield return new WaitForSeconds(attack.duration);

        _pendingAttack = false;
        _state = MeleeState.Cooldown;
        yield return new WaitForSeconds(attack.cooldown);

        ComboCounter++;
        _state = MeleeState.Idle;

        if (_pendingAttack)
        {
            StartCoroutine(PerformAttack());
            yield break;
        }
        yield return new WaitForSeconds(config.ComboCooldown);

        if (!IsAttacking) ComboCounter = 0;
    }

    private IEnumerator DealDamage(AttackInfo attack)
    {
        while (_state == MeleeState.Execution)
        {
            var results = Physics2D.CircleCastAll(attackOffset.position, attack.range,
                transform.right, 0f, layers);

            foreach (var result in results)
            {
                var damageable = result.collider.GetComponent<IDamageable>();
                damageable?.TakeDamage(attack.damage);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void SetupInput(InputManager inputManager)
    {
        if (!inputManager) return;

        inputManager.onAttack += Attack;
    }

    public void RemoveInput(InputManager inputManager)
    {
        if (!inputManager) return;

        inputManager.onAttack -= Attack;
    }

    private void OnDrawGizmos()
    {
        if (config.Attaks.Count == 0) return;
        Gizmos.DrawWireSphere(attackOffset.position, config.Attaks[0].range);
    }
}
