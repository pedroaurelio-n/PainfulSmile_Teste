using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
    public class GameData : ScriptableObject
    {
        public int HighScore;
        public float GameDuration;
        public float EnemySpawnTime;
    }
}
