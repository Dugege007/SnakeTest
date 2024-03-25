using UnityEngine.UI;

namespace SnakeTest
{
    public class GameUI : MonoSingleton<GameUI>
    {
        public Text ScoreText;
        private int tempScore;

        private void Start()
        {
           
        }

        private void Update()
        {
            if (GameManager.Instance.Score != tempScore)
            {
                ScoreText.text = GameManager.Instance.Score.ToString();
                tempScore = GameManager.Instance.Score;
            }
        }
    }
}
