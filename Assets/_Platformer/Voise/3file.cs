using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScaleFrommicrophone : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;
    public float LoundnessSemsibility = 100;
    public float Threshold = 0.1f;
    void Start()
    {

    }
    void Update()
    {
        float loudness = detector.GetloudnessFrommicrophone() * loudnessSensibility;
        if (loudness < threshold)
            loudness = 0;
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}