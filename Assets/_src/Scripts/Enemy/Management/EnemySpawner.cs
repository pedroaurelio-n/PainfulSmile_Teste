using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData data;
        
        [Header("Dependencies")]
        [SerializeField] private Transform target;
        [SerializeField] private List<Enemy> enemyPrefabs;
        [SerializeField] private List<Transform> spawnPositions;

        private float _spawnTime;
        private WaitForSeconds _waitForSpawnTime;
        private Coroutine _spawnCoroutine;

        private void Awake()
        {
            _spawnTime = data.EnemySpawnTime;

            _waitForSpawnTime = new WaitForSeconds(_spawnTime);

            _spawnCoroutine = StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return _waitForSpawnTime;

                var randomSpawn = spawnPositions[Random.Range(0, spawnPositions.Count)];
                var randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

                var enemy = Instantiate(randomEnemy, randomSpawn.position, transform.rotation, transform);
                enemy.Target = target;
            }
        }

        private void DisableSpawning() => StopCoroutine(_spawnCoroutine);

        protected virtual void OnEnable()
        {
            Player.onPlayerDeath += DisableSpawning;
            ShowGameTime.onEndSession += DisableSpawning;
        }

        protected void OnDisable()
        {
            Player.onPlayerDeath -= DisableSpawning;
            ShowGameTime.onEndSession -= DisableSpawning;
        }
    }
}
