using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.SumoBall
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab = null;
        public GameObject powerupPrefab = null;
        public int enemyCount { get; private set; }
        public int waveNumber = 1;

        private float spawnRange = 9.0f; // prevent spawning from outside the map

        // Start is called before the first frame update
        void Start()
        {
            SpawnEnemyWave(waveNumber);
        }

        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;

            if (enemyCount == 0)
            {
                waveNumber++; // next wave
                SpawnEnemyWave(waveNumber);
                Instantiate(powerupPrefab, RandomPosition(), powerupPrefab.transform.rotation);
            }
        }

        private Vector3 RandomPosition()
        {
            // spawn an enemy at a random point
            float spawnPositionX = Random.Range(-spawnRange, spawnRange);
            float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
            return new Vector3(spawnPositionX, 0, spawnPositionZ);            
        }

        void SpawnEnemyWave(int enemiesToSpawn)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, RandomPosition(), enemyPrefab.transform.rotation);
            }
        }

    }
}
