using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PedroAurelio.PainfulSmile
{
    [RequireComponent(typeof(Button))]
    public class SettingsButtonHighlight : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData data;

        [Header("Settings")]
        [SerializeField] private float buttonValue;
        [SerializeField] private SettingsType settingsType;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => UpdateButtonState();

        public void UpdateButtonState()
        {
            switch (settingsType)
            {
                case SettingsType.GameDuration:
                    _button.interactable = data.GameDuration == buttonValue ? false : true;
                    break;

                case SettingsType.EnemySpawnTime:
                    _button.interactable = data.EnemySpawnTime == buttonValue ? false : true;
                    break;
            }
        }

        enum SettingsType
        {
            GameDuration,
            EnemySpawnTime
        }
    }
}
