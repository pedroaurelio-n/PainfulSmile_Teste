using UnityEngine;
using TMPro;

namespace PedroAurelio.PainfulSmile
{
    public class GameOverController : MonoBehaviour
    {
        [Header("Game Data")]
        [SerializeField] private GameData data;

        [Header("General Dependencies")]
        [SerializeField] private ShowScore score;
        [SerializeField] private ShowGameTime gameTime;
        [SerializeField] private GameObject panel;
        [SerializeField] private TextMeshProUGUI title;

        [Header("Score Dependencies")]
        [SerializeField] private TextMeshProUGUI gameScoreNumber;
        [SerializeField] private TextMeshProUGUI highScoreNumber;

        [Header("Settings")]
        [SerializeField] private string winText;
        [SerializeField] private Color winColor;
        [SerializeField] private string lossText;
        [SerializeField] private Color lossColor;

        private void GameWon() => ShowGameOverPanel(true);
        private void GameLost() => ShowGameOverPanel(false);

        private void ShowGameOverPanel(bool gameWon)
        {
            panel.SetActive(true);

            if (gameWon)
            {
                title.text = winText;
                title.color = winColor;
            }
            else
            {
                title.text = lossText;
                title.color = lossColor;
            }

            UpdateScores();

            gameTime.gameObject.SetActive(false);
            score.gameObject.SetActive(false);
        }

        private void UpdateScores()
        {
            highScoreNumber.text = data.HighScore.ToString("00");
            gameScoreNumber.text = score.CurrentScore.ToString("00");

            if (score.CurrentScore > data.HighScore)
            {
                data.HighScore = score.CurrentScore;
                highScoreNumber.text = gameScoreNumber.text;
            }
        }

        private void OnEnable()
        {
            Player.onPlayerDeath += GameLost;
            ShowGameTime.onEndSession += GameWon;
        }

        private void OnDisable()
        {
            Player.onPlayerDeath -= GameLost;
            ShowGameTime.onEndSession -= GameWon;
        }
    }
}
