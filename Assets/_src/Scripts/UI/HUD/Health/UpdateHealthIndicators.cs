using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class UpdateHealthIndicators : MonoBehaviour
    {
        [SerializeField] private HealthIndicator indicatorPrefab;
        
        private static HealthIndicator _indicator;
        private static Transform _canvasTransform;
        private static List<HealthIndicator> _indicatorList;

        private void Awake()
        {            
            _indicator = indicatorPrefab;
            _indicatorList = new List<HealthIndicator>();
            _canvasTransform = transform;
        }

        private void Update()
        {
            if (_indicatorList.Count == 0)
                return;

            for (int i = 0; i < _indicatorList.Count; i++)
            {
                _indicatorList[i].UpdatePosition();
                _indicatorList[i].UpdateHealth();
            }
        }

        public static void RequestHealthIndicator(Health health, Vector2 offset)
        {
            var indicator = Instantiate(_indicator, health.transform.position, Quaternion.identity, _canvasTransform);
            indicator.Initialize(health, offset);

            if (!_indicatorList.Contains(indicator))
                _indicatorList.Add(indicator);
        }

        public static void RemoveIndicatorFromList(HealthIndicator indicator)
        {
            if (_indicatorList.Contains(indicator))
                _indicatorList.Remove(indicator);
        }

        private void OnDisable() => _indicatorList.Clear();
    }
}
