using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuber : MonoBehaviour
{
    public GameObject Tubes;
    
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            float rand = Random.Range(-1f, 4f);
            Instantiate(Tubes, new Vector3(-175, rand, 0), Quaternion.identity);
        }
    }
}
