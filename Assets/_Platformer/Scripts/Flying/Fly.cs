using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int voiceTreshold;
    [SerializeField] public float speed = 3;
    [SerializeField] private GameObject gameObject; 
    [SerializeField] private int lowTreshold = 1;
    [SerializeField] private int highTreshold = 32;
    public AudioLoudnessDetection detector;
    private Vector2 objectPos;
    void FixedUpdate()
    {
        float plank =  voiceTreshold * (highTreshold - lowTreshold) / detector.GetLoudnessFromAudioClip();
        objectPos = gameObject.transform.position;
        if (objectPos.y < plank) 
        {
            transform.Translate(-speed * Time.fixedDeltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(speed * Time.fixedDeltaTime, 0f, 0f);
        }
    }   
}




































































/*응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응응*/