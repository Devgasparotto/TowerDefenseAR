using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {
    public static WaveSpawner instance;

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    
    private float countdown = 2f;
    private int waveIndex = 0;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one WaveSpawner in scene");
        }
        instance = this;
    }

    void Update()
    {
        //start spawning enemies
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            //Wait to spawn next enemy
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void ResetWaves()
    {
        countdown = 2f;
        waveIndex = 0;
    }

}
