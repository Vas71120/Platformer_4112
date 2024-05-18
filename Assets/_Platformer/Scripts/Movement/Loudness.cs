using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Loudness : MonoBehaviour
{
    int sampleWindow = 64;
    public float GetLoudness(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0)
            return 0;
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);
        float totalLoudness = 0;
        for(int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Math.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
