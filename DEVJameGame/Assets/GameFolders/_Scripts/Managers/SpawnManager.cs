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
    
    
    private void Start()
    {
        coroutine = SpawnVirus(4f);
        StartCoroutine(coroutine);
        StartCoroutine("SpawnCollectableBomb");
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

    private IEnumerator SpawnCollectableBomb()
    {
        while (true)
        {
            if(player.bombNumber < 5)
            {
                float spawnrate = Random.Range(3f, 10f);
                yield return new WaitForSeconds(spawnrate);
                Vector3 spawnPos = new Vector3(Random.Range(-12f, 12f), 16.37f, Random.Range(-8f, 8f));
                Instantiate(collectableBomb, spawnPos, transform.rotation);
            }
        }
    }
}
