using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.SumoBall
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab = null;

        private float spawnRange = 9.0f; // prevent spawning from outside the map

        // Start is called before the first frame update
        void Start()
        {
            // spawn an enemy at a random point
            float spawnPositionX = Random.Range(-spawnRange, spawnRange);
            float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
            Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

            Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
