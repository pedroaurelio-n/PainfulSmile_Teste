using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PedroAurelio.PainfulSmile
{
    public class ShowGameTime : MonoBehaviour
    {
        public delegate void EndSession();
        public static event EndSession onEndSession;

        [Header("Dependencies")]
        [SerializeField] private TextMeshProUGUI timeNumber;

        private float _timeRemaining;
        private bool _hasSessionEnded;

        private void Awake() => _timeRemaining = 120f;

        private void Update()
        {
            if (_timeRemaining > 0f)
            {
                _timeRemaining -= Time.deltaTime;
                timeNumber.text = _timeRemaining.ToString("00");
                return;
            }

            if (!_hasSessionEnded)
            {
                onEndSession?.Invoke();
                _hasSessionEnded = true;
            }
        }
    }
}
