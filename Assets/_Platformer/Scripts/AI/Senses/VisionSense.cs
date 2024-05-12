using Cinemachine;
using MBT;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisionSense : MonoBehaviour
{
    [SerializeField, Min(0f)] private float distance = 10f;
    [SerializeField, Range(0, 90f)] private float coneHalfAngle = 30f;
    [TagField]
    [SerializeField] private string[] tags = { "Player" };
    [SerializeField] private LayerMask layers = 1;

    private float ConeHalfAngle => Mathf.Cos(coneHalfAngle);

    public IEnumerable<Transform> GetTriggers()
    {
        var position = transform.position;
        var right = transform.right;

        var results = Physics2D.CircleCastAll(position, distance, right, 0f, layers);
       
        return from result in results
                where tags.Contains(result.transform.tag)
                let location = result.transform.position
                let direction = location - position
                let dot = Vector3.Dot(direction.normalized, right)
                where dot >= ConeHalfAngle
                let hit = Physics2D.Linecast(position, location, layers)
                where hit.transform == hit.transform
                select result.transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        GizmosExtensions.DrawWireArc(transform.position, transform.right, coneHalfAngle * 2, distance);
    }
}

public class GizmosExtensions
{
    private GizmosExtensions() { }

    /// <summary>
    /// Draws a wire arc.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="dir">The direction from which the anglesRange is taken into account</param>
    /// <param name="anglesRange">The angle range, in degrees.</param>
    /// <param name="radius"></param>
    /// <param name="maxSteps">How many steps to use to draw the arc.</param>
    public static void DrawWireArc(Vector3 position, Vector3 dir, float anglesRange, float radius, float maxSteps = 20)
    {
        var srcAngles = GetAnglesFromDir(position, dir);
        var initialPos = position;
        var posA = initialPos;
        var stepAngles = anglesRange / maxSteps;
        var angle = srcAngles - anglesRange / 2;
        for (var i = 0; i <= maxSteps; i++)
        {
            var rad = Mathf.Deg2Rad * angle;
            var posB = initialPos;
            posB += new Vector3(radius * Mathf.Cos(rad), radius * Mathf.Sin(rad), 0f);

            Gizmos.DrawLine(posA, posB);

            angle += stepAngles;
            posA = posB;
        }
        Gizmos.DrawLine(posA, initialPos);
    }

    static float GetAnglesFromDir(Vector3 position, Vector3 dir)
    {
        var forwardLimitPos = position + dir;
        var srcAngles = Mathf.Rad2Deg * Mathf.Atan2(forwardLimitPos.y - position.y, forwardLimitPos.x - position.x);

        return srcAngles;
    }
}