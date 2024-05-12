using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{ 
    [SerializeField] private string speedParameterName = "Speed";
    [SerializeField] private string verticalSpeedParameterName = "VerticalSpeed";
    [SerializeField] private string isFallingParameterName = "IsFalling";
    [SerializeField] private string hurtTriggerName = "Hurt";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetVelocity(Vector2 velocity)
    {
        _animator.SetFloat(speedParameterName, Mathf.Abs(velocity.x));
        _animator.SetFloat(verticalSpeedParameterName, velocity.y);
    }

    public void SetIsFalling(bool isFalling)
    {
        _animator.SetBool(isFallingParameterName, isFalling);
    }

    public void Hurt()
    {
        _animator.SetTrigger(hurtTriggerName);
    }
}
