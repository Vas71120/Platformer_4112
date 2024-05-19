using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tuber : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawn = 2f;
    [SerializeField] private float pipeSpeed = 2f;
    [SerializeField] private float pipeLifetime = 20f;
    [Space]
    [SerializeField] private GameObject[] Tubes;
    
    private void OnEnable()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var spawnPoint = transform.position;
        
        while(enabled)
        {
            var rand = Random.Range(0, Tubes.Length);
            var go = Instantiate(Tubes[rand], spawnPoint, Quaternion.identity);
            
            var pipe = go.AddComponent<TubeMover>();
            pipe.speed = pipeSpeed;
            
            Destroy(go, pipeLifetime);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
