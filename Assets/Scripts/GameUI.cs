using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SnakeTest
{
    public class GameUI : MonoSingleton<GameUI>
    {
        private GameManager gameManager;

        public Image GameOverPanel;
        private bool isGameOver = false;

        public Image HelpPanel;

        public Text ScoreText;
        public Text TopScoreText;
        public Text NewRecordText;

        private void Start()
        {
            gameManager = GameManager.Instance;

            GameOverPanel.Hide();
            HelpPanel.Hide();
            NewRecordText.Hide();

            // 监听分数变化
            gameManager.Score.RegisterWithInitValue(score =>
            {
                ScoreText.text = score.ToString();

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
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

            // 查看帮助
            if (Input.GetKeyDown(KeyCode.H))
            {
                HelpPanel.Show();
                Time.timeScale = 0f;
            }

            if (Input.GetKeyUp(KeyCode.H))
            {
                HelpPanel.Show();
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
