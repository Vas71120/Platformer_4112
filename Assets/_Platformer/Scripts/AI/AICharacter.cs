using MBT;
using System.Linq;
using UnityEngine;

public class AICharacter : Character
{
    [Header("AI")]
    [SerializeField] private Blackboard blackboard;
    [SerializeField] private string enemyKey = "Enemy";
    [SerializeField] private VisionSense vision;
    [Space]
    [SerializeField] private Walking walking;
    [SerializeField] private Weapon weapon;

    private GameObjectVariable _enemy;

    public Walking Walking => walking;
    public Weapon Weapon => weapon;

    protected override void OnEnable()
    {
        base.OnEnable();
        _enemy = blackboard.GetVariable<GameObjectVariable>(enemyKey);
    }

    private void FixedUpdate()
    {
        if (!vision) return;
        _enemy.Value = vision.GetTriggers().FirstOrDefault(x => x.transform != transform)?.gameObject;
    }
}
