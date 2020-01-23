using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnYLimit = 6f;
    void Start()
    {
        Spawn();
    }

    
    void Spawn()
    {
        float random = Random.Range (-spawnYLimit, spawnYLimit);
        Vector3 spawnPos = transform.position + new Vector3(0f, random, 0f);
        Instantiate(spawnPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
