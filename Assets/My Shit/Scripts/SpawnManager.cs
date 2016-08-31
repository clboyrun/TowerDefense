using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public Transform[] SpawnPoints;
    public GameObject[] Enemies;

    public bool isSpawning = false;
    public float spawnWaveTimer = 0f;
    public float spawnWaveTimerCurrent = 0f;
    public float spawnWaveMin = 0f;
    public float spawnWaveMax = 0f;
    public float spawnWaveNextWave = 0f;
    public int spawnWaveCount;
    public int spawnWaveMinCount = 0;
    public int spawnWaveMaxCount = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning == false && spawnWaveNextWave <= 0f)
        {
            spawnWaveNextWave = Random.Range(spawnWaveMin, spawnWaveMax);
        }

        if (isSpawning == false && spawnWaveNextWave > 0f)
        {
            spawnWaveNextWave -= Time.deltaTime;

            if (spawnWaveNextWave <= 0f)
            {
                isSpawning = true;

                spawnWaveCount = Random.Range(spawnWaveMinCount, spawnWaveMaxCount);
                spawnWaveTimerCurrent = 0f;
            }
        }

        if (isSpawning == true)
        {
            if (spawnWaveTimerCurrent > 0f)
            {
                spawnWaveTimerCurrent -= Time.deltaTime;
            }

            if (spawnWaveTimerCurrent <= 0f)
            {
                spawnWaveCount--;
                Spawn();
                spawnWaveTimerCurrent = spawnWaveTimer;
            }

            if (spawnWaveCount <= 0)
            {
                isSpawning = false;
            }
        }
    }

    void Spawn()
    {
        int randomSpawn = Random.Range(0, SpawnPoints.Length);

        Debug.Log("Spawning at " + SpawnPoints[randomSpawn].position);
        Instantiate(Enemies[0], SpawnPoints[randomSpawn].position, Enemies[0].transform.rotation);
    }
}
