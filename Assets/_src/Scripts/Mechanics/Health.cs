using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Health : MonoBehaviour
    {
        public float CurrentHealth => _currentHealth;
        public float MaxHealth => maxHealth;

        [Header("Settings")]
        [SerializeField] private float maxHealth;

        private float _currentHealth;

        private ShipAnimation _shipAnimation;
        private IKillable _killable;

        private void Awake()
        {
            if (!TryGetComponent<IKillable>(out _killable))
                Debug.LogError($"Health component needs reference to an IKillable in the same object.");

            _shipAnimation = GetComponentInChildren<ShipAnimation>();
        }

        private void OnEnable() => _currentHealth = maxHealth;

        public void ModifyHealth(float value)
        {
            _currentHealth += value;

            if (_shipAnimation != null)
                _shipAnimation.UpdateShipSprite(_currentHealth, maxHealth);

            if (_currentHealth <= 0)
                _killable.Die();
        }
    }
}
