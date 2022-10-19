using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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

        private ObjectPool<Enemy> _enemyPool;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(OnCreateEnemy, OnGetEnemy, OnReleaseEnemy);

            _spawnTime = data.EnemySpawnTime;

            _waitForSpawnTime = new WaitForSeconds(_spawnTime);

            StartCoroutine(SpawnCoroutine());
        }

        #region Pooling Methods
        private Enemy OnCreateEnemy()
        {
            var randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

            var enemy = Instantiate(randomEnemy, transform);
            enemy.gameObject.SetActive(false);

            enemy.Target = target;
            enemy.SetPool(_enemyPool);
            return enemy;
        }

        private void OnGetEnemy(Enemy enemy)
        {
            var randomPosition = spawnPositions[Random.Range(0, spawnPositions.Count)];
            enemy.Initialize(randomPosition.position);
            
            enemy.gameObject.SetActive(true);
        }
        private void OnReleaseEnemy(Enemy enemy) => enemy.gameObject.SetActive(false);
        #endregion

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return _waitForSpawnTime;

                var enemy = _enemyPool.Get();
            }
        }
    }
}
