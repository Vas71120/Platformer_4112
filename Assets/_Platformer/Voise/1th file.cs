using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScaleFromAudioClip : MonoBehaviour
{


    public AudioDource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;
    public float LoundnessSemsibility = 100;
    public float Threshold = 0.1f;
	{
		float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;
		if(loudness<threshold)

            loudness = 0;
		transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
	}
}
