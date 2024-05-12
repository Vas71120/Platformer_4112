using UnityEngine;

public class Walking : MonoBehaviour, IInputable
{
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;
    [Space]
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Ground ground;
    [Space]
    [SerializeField] [HideInInspector] private CharacterAnimator animator;

    private InputManager _inputManager;

    private Vector2 _direction;
    private Vector2 _desiredVelocity;

    private Vector2 _velocity;
    
    private bool _onGround;

    public void SetupInput(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    public void RemoveInput(InputManager inputManager)
    {
        _inputManager = null;
    }

    public void Move(Vector2 direction)
    {
        _direction.x = direction.normalized.x;
        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(maxSpeed - ground.Friction, 0f);
    }

    private void Update()
    {
        if (_inputManager)
        {
            Move(_inputManager.Move);
        }

        animator.SetVelocity(_velocity);
        animator.SetIsFalling(!_onGround);
    }

    private void FixedUpdate()
    {
        _onGround = ground.OnGround;
        _velocity = body.velocity;

        var acceleration = _onGround ? maxAcceleration : maxAirAcceleration;
        var speedChange = acceleration * Time.fixedDeltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, speedChange);

        body.velocity = _velocity;
    }
}
