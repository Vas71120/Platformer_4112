using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScaleFromAudioClip : MonoBehaviour
{


    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;
    public float LoundnessSemsibility = 100;
    public float Threshold = 0.1f;
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * LoundnessSemsibility;
        if (loudness < Threshold) loudness = 0;
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}