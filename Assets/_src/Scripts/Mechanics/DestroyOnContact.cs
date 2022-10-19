using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class DestroyOnContact : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private LayerMask contactLayers;

        private void CheckForContact(GameObject other)
        {
            var objectLayer = other.layer;
            var objectIsInContactLayer = (1 << objectLayer & contactLayers) != 0;

            if (objectIsInContactLayer)
            {
                if (TryGetComponent<IPoolable>(out IPoolable poolable))
                    poolable.ReleaseFromPool();
                else
                    gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) => CheckForContact(other.gameObject);

        private void OnTriggerEnter2D(Collider2D other) => CheckForContact(other.gameObject);
    }
}
