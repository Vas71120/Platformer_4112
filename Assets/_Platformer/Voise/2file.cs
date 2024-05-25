using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioLoudnessDetection : MonoBehaviour
{
    private MicrophoneClip
    public int sampleWindow = 64;

    private AudioClip microphoneClip;
	void Start()
    {
        MicrophoneToAudioClip();
    }
    void Update()
    {

    }
    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings);
    }
    public float GetLoudnessFromAudioClip()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]),microphoneClip);
    }
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0)
            return 0;
        float[] waveData = new float[sampleWindow];
        clip / PenData(waveData, startPosition);

        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow: i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}