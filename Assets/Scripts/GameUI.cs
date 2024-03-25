using UnityEngine.UI;

namespace SnakeTest
{
    public class GameUI : MonoSingleton<GameUI>
    {
        private GameManager gameManager;

        public Image GameOverPanel;
        private bool isGameOver = false;

        public Text ScoreText;
        private int tempScore;
        public Text TopScoreText;
        public Text NewRecordText;

        private void Start()
        {
            gameManager = GameManager.Instance;

            GameOverPanel.gameObject.SetActive(false);
            NewRecordText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (gameManager == null || isGameOver) return;

            if (gameManager.Score != tempScore)
            {
                ScoreText.text = gameManager.Score.ToString();
                tempScore = gameManager.Score;
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
