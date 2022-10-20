using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Health))]
    public class ShowHealthOnHud : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector2 offset;

        private Health _health;

        private bool _hasIndicator;

        private void Awake() => _health = GetComponent<Health>();

        private void OnEnable() => UpdateHealthIndicators.RequestHealthIndicator(_health, offset);
    }
}
