using UnityEngine;
using TMPro;

namespace PedroAurelio.PainfulSmile
{
    public class HealthIndicator : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI healthNumber;

        private Health _health;
        private Transform _target;
        private Vector2 _offset;

        public void Initialize(Health targetHealth, Vector2 offset)
        {
            _health = targetHealth;
            _target = _health.transform;
            _offset = offset;
        }

        public void UpdatePosition()
        {
            if (_target != null)
                transform.position = _target.position + (Vector3)_offset;
        }

        public void UpdateHealth()
        {
            healthNumber.text = $"{(int)_health.CurrentHealth}/{(int)_health.MaxHealth}";

            if (_health.CurrentHealth <= 0f)
            {
                UpdateHealthIndicators.RemoveIndicatorFromList(this);
                Destroy(gameObject);
            }
        }
    }
}
