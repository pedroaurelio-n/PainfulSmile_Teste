using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class ShipAnimation : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private ParticleSystem damageParticles;
        [SerializeField] private ParticleSystem deathParticles;

        [Header("Sprites")]
        [SerializeField] private Sprite fullHealth;
        [SerializeField] private Sprite damaged;
        [SerializeField] private Sprite destroyed;

        [Header("Settings")]
        [SerializeField, Range(0f, 1f)] private float damagedThreshold = 0.67f;
        [SerializeField, Range(0f, 1f)] private float destroyedThreshold = 0.33f;

        private SpriteRenderer _spriteRenderer;

        private void OnValidate()
        {
            if (damagedThreshold < destroyedThreshold)
                damagedThreshold = destroyedThreshold;
        }

        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        public void UpdateShipSprite(float currentHealth, float maxHealth)
        {
            damageParticles.Play();

            var healthPercentage = currentHealth / maxHealth;

            if (healthPercentage > damagedThreshold)
                _spriteRenderer.sprite = fullHealth;
            else if (healthPercentage <= damagedThreshold && healthPercentage > destroyedThreshold)
                _spriteRenderer.sprite = damaged;
            else
                _spriteRenderer.sprite = destroyed;

            if (currentHealth <= 0f)
            {
                deathParticles.transform.SetParent(null);
                deathParticles.gameObject.SetActive(true);
            }
        }
    }
}
