using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IPoolable
    {
        private Rigidbody2D _rigidbody;

        private IObjectPool<Bullet> _pool;
        private bool _isActiveOnPool;

        private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

        public void SetPool(IObjectPool<Bullet> pool) => _pool = pool;

        public void Initialize(Vector3 position, Vector3 rotation, float speed)
        {
            _isActiveOnPool = true;

            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);
            _rigidbody.velocity = transform.right * speed;
        }

        public void ReleaseFromPool()
        {
            if (_isActiveOnPool)
            {
                _isActiveOnPool = false;
                _pool.Release(this);
            }
        }
    }
}
