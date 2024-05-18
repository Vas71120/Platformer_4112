using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float force;
    Rigidbody2D Rigid;
    public int sampleWindow = 5;
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigid.velocity = Vector2.up * force;
    }
}
