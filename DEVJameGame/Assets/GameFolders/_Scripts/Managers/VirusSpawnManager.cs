using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class VirusSpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> virusList;
    private Vector3 spawnPos;
    private IEnumerator coroutine;
    private void Start()
    {
        coroutine = SpawnVirus(4f);
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        SetBounds();
    }

    private void SetBounds()
    {
        float xBound = Random.Range(-8f, 8f);
        float zBound = Random.Range(-11f, 11f);
        spawnPos = new Vector3(xBound, transform.position.y, zBound);
    }
    
    private IEnumerator SpawnVirus(float spawnRate)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(spawnRate);
            int virusIndex = Random.Range(0, 4);
            Instantiate(virusList[virusIndex], spawnPos, transform.rotation);    
        }
    }
}
