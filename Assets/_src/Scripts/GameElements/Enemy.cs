using UnityEngine;
using UnityEngine.Pool;

namespace PedroAurelio.PainfulSmile
{
    public class Enemy : MonoBehaviour, IKillable, IPoolable
    {
        public delegate void EnemyDefeated(int score);
        public static event EnemyDefeated onEnemyDefeated;

        public Transform Target { get; set; }

        [Header("Settings")]
        [SerializeField] private int scoreOnDefeat;

        private IObjectPool<Enemy> _pool;
        private bool _isActiveOnPool;

        public void SetPool(IObjectPool<Enemy> pool) => _pool = pool;

        public void Initialize(Vector3 position)
        {
            _isActiveOnPool = true;

            transform.position = position;
        }

        public void ReleaseFromPool()
        {
            if (_isActiveOnPool)
            {
                _isActiveOnPool = false;
                _pool.Release(this);
            }
        }

        public void Die()
        {
            onEnemyDefeated?.Invoke(scoreOnDefeat);
            ReleaseFromPool();
        }
    }
}
