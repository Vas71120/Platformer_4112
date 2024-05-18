using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        var rot = transform.eulerAngles;

        rot.y = _rigidbody.velocity.x switch
        {
            > 0 => 0f,
            < 0 => 180f,
            _ => rot.y
        };

        transform.eulerAngles = rot;
    }
}
