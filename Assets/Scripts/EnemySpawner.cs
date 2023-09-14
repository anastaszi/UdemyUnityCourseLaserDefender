using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0.5f;
    [SerializeField] bool isLooping = false;
    WaveConfig currentWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    public WaveConfig GetCurrentWave() {
        return currentWave;
    }

    IEnumerator SpawnEnemies() {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingWaypoint().position, 
                                Quaternion.identity, transform);
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
        
    }

    IEnumerator SpawnAllWaves() {
        do {foreach (WaveConfig waveConfig in waveConfigs) {
            currentWave = waveConfig;
            yield return StartCoroutine(SpawnEnemies());
            yield return new WaitForSeconds(timeBetweenWaves);
        }} while (isLooping);
    }



}
