using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PedroAurelio.PainfulSmile
{
    public class SettingsController : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData data;

        public void SetGameDuration(float value) => data.GameDuration = value;
        public void SetEnemySpawnTime(float value) => data.EnemySpawnTime = value;
    }
}
