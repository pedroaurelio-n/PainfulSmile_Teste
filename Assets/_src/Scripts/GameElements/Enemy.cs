using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public delegate void EnemyDefeated(int score);
        public static event EnemyDefeated onEnemyDefeated;

        public Transform Target { get; set; }

        [Header("Settings")]
        [SerializeField] private int scoreOnDefeat;

        public void Die()
        {
            onEnemyDefeated?.Invoke(scoreOnDefeat);
            Destroy(gameObject);
        }
    }
}
