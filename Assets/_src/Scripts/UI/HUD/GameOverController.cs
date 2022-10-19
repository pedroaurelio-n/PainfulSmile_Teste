using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PedroAurelio.PainfulSmile
{
    public class GameOverController : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData data;

        [Header("General Dependencies")]
        [SerializeField] private GameObject panel;
        [SerializeField] private TextMeshProUGUI title;

        [Header("Score Dependencies")]
        [SerializeField] private ShowScore score;
        [SerializeField] private TextMeshProUGUI gameScoreNumber;
        [SerializeField] private TextMeshProUGUI highScoreNumber;

        [Header("Settings")]
        [SerializeField] private string winText;
        [SerializeField] private Color winColor;
        [SerializeField] private string lossText;
        [SerializeField] private Color lossColor;

        private void ShowGameLostPanel()
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            title.text = lossText;
            title.color = lossColor;

            UpdateScores();
        }

        private void ShowGameWonPanel()
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            title.text = winText;
            title.color = winColor;

            UpdateScores();
        }

        private void UpdateScores()
        {
            highScoreNumber.text = data.HighScore.ToString("00");
            gameScoreNumber.text = score.CurrentScore.ToString("00");

            if (score.CurrentScore > 0f)
            {
                data.HighScore = score.CurrentScore;
                highScoreNumber.text = gameScoreNumber.text;
            }
        }

        private void OnEnable()
        {
            Player.onPlayerDeath += ShowGameLostPanel;
            ShowGameTime.onEndSession += ShowGameWonPanel;
        }

        private void OnDisable()
        {
            Player.onPlayerDeath -= ShowGameLostPanel;
            ShowGameTime.onEndSession -= ShowGameWonPanel;
            Time.timeScale = 1f;
        }
    }
}
