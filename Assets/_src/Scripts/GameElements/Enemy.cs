using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public delegate void AddScore(int score);
        public static event AddScore onAddScore;

        public static List<Enemy> EnemyInstances { get; set; } = new List<Enemy>();

        public Transform Target { get; set; }

        [Header("Settings")]
        [SerializeField] private int scoreOnDefeat;

        private void Awake() => EnemyInstances.Add(this);

        public void Die()
        {
            onAddScore?.Invoke(scoreOnDefeat);
            EnemyInstances.Remove(this);
            Destroy(gameObject);
        }
    }
}
