using MBT;
using System.Collections;
using UnityEngine;

[AddComponentMenu("")]
[MBTNode("Tasks/Attack")]
public class AttackTask : Leaf
{
    [SerializeField] private AICharacterReference self = new(VarRefMode.DisableConstant);
    [SerializeField] private FloatReference attackRate = new(1f);

    private bool _isAttacking;

    public override NodeResult Execute()
    {
        if (_isAttacking) return NodeResult.running;

        self.Value.Weapon.Attack();
        StartCoroutine(DoCooldown(attackRate.Value));

        return NodeResult.success;
    }

    private IEnumerator DoCooldown(float duration)
    {
        _isAttacking = true;
        yield return new WaitForSeconds(duration);
        _isAttacking = false;
    }
}
