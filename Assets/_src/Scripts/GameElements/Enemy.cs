using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public delegate void AddScore(int score);
        public static event AddScore onAddScore;

        public static int ActiveCount => _enemyInstances.Count;
        private static List<Enemy> _enemyInstances = new List<Enemy>();

        public Transform Target { get; set; }

        [Header("Settings")]
        [SerializeField] private int scoreOnDefeat;

        private void Awake() => _enemyInstances.Add(this);

        public void Die()
        {
            onAddScore?.Invoke(scoreOnDefeat);
            _enemyInstances.Remove(this);
            Destroy(gameObject);
        }
    }
}
