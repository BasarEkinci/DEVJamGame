using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnManager : MonoBehaviour
{ 
    [SerializeField] List<GameObject> virusList;
    [SerializeField] GameObject collectableBomb;
    [SerializeField] PlayerCombat player;
    private Vector3 spawnPos;
    private IEnumerator coroutine;
    private bool isSpawnBombEnable;
    
    private void Start()
    {
        coroutine = SpawnVirus(4f);
        StartCoroutine(coroutine);
        InvokeRepeating("SpawnCollectableBomb",1f,5f);
    }

    private void Update()
    {
        SetBounds();
        isSpawnBombEnable = player.bombNumber < 5;
        Debug.Log(GameManager.Instance.IsGameStarted);
    }

    private void SetBounds()
    {
        float xBound = Random.Range(-8f, 8f);
        float zBound = Random.Range(-11f, 11f);
        spawnPos = new Vector3(xBound, transform.position.y, zBound);
    }
    
    private IEnumerator SpawnVirus(float spawnRate)
    {
        while (GameManager.Instance.IsGameStarted)
        {
            int virusIndex = Random.Range(0, 4);
            Instantiate(virusList[virusIndex], spawnPos, transform.rotation);    
            yield return new WaitForSecondsRealtime(spawnRate);
        }
    }

    private void SpawnCollectableBomb()
    {
        float chance = Random.Range(0f, 8f);
        if(isSpawnBombEnable && chance <= 4f)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-12f, 12f), 16.37f, Random.Range(-8f, 8f)); 
            Instantiate(collectableBomb, spawnPos, transform.rotation);
        }
    }
}
