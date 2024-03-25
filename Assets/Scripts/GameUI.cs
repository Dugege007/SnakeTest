using UnityEngine;
using UnityEngine.UI;

namespace SnakeTest
{
    public class GameUI : MonoSingleton<GameUI>
    {
        private GameManager gameManager;

        public Image GameOverPanel;
        private bool isGameOver = false;

        public Image HelpPanel;

        public Text ScoreText;
        private int tempScore;
        public Text TopScoreText;
        public Text NewRecordText;

        private void Start()
        {
            gameManager = GameManager.Instance;

            GameOverPanel.gameObject.SetActive(false);
            HelpPanel.gameObject.SetActive(false);

            NewRecordText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (gameManager == null) return;

            if (isGameOver)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }

            if (gameManager.Score != tempScore)
            {
                ScoreText.text = gameManager.Score.ToString();
                tempScore = gameManager.Score;
            }

            // ²é¿´°ïÖú
            if (Input.GetKeyDown(KeyCode.H))
            {
                HelpPanel.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }

            if (Input.GetKeyUp(KeyCode.H))
            {
                HelpPanel.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        public void GameOver()
        {
            isGameOver = true;

            GameOverPanel.gameObject.SetActive(true);
            TopScoreText.text = gameManager.TopScore.ToString();

            if (gameManager.IsNewRecord)
                NewRecordText.gameObject.SetActive(true);
        }
    }
}
