using UnityEngine;

public class TubeMover : MonoBehaviour
{
    [SerializeField] public float speed;

    private void FixedUpdate()
    {
        transform.Translate( -speed * Time.fixedDeltaTime, 0f, 0f);
    }
}
