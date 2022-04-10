using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnDistance;
    public float spawnRate;
    public float minSpawnRate;
    public float timeToMinSpawnRate;
    
    private float spawnRateMod;
    private float lastSpawnTime;
    private float curSpawnRate;

    public bool canSpawn;

    public GameObject enemyPrefab;

    public static EnemySpawn instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        curSpawnRate = spawnRate;
        spawnRateMod = (minSpawnRate - spawnRate) / timeToMinSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canSpawn)
        {
            return;
        }
        if(Time.time - lastSpawnTime > curSpawnRate)
        {
            SpawnEnemy();
        }
        if(spawnRate > minSpawnRate)
        {
            spawnRate -= spawnRateMod * Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        lastSpawnTime = Time.time;
        Vector3 spawnCircle = Random.onUnitSphere;
        spawnCircle.y = Mathf.Abs(spawnCircle.y);
        Vector3 spawnPos = ShootCore.instance.transform.position + (spawnCircle * spawnDistance);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
