using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class DestroyByLifeTime : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float lifeTime;

        private WaitForSeconds _waitForLifeTime;

        private void Awake() => _waitForLifeTime = new WaitForSeconds(lifeTime);
        private void OnEnable() => StartCoroutine(DestroyCoroutine());

        private IEnumerator DestroyCoroutine()
        {
            yield return _waitForLifeTime;

            if (TryGetComponent<IPoolable>(out IPoolable poolable))
                poolable.ReleaseFromPool();
            else
                gameObject.SetActive(false);
        }
    }
}
