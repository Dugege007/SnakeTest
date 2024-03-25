using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakeTest
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Snake Snake;
        public bool IsGaming = true;

        public int Score = 0;
        public int TopScore = 0;
        public bool IsNewRecord = false;

        private bool needSpeedUp = false;

        protected override void Awake()
        {
            base.Awake();

            Load();

            if (Snake == null)
                Snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<Snake>();
        }

        private void Update()
        {
            if (IsGaming == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Game");
                }
            }

            if (Score > 0 && Score % 10 == 0)
            {
                needSpeedUp = true;

                if (needSpeedUp)
                {
                    Snake.SpeedUp();
                    needSpeedUp = false;
                }
            }
        }

        public void GameOver()
        {
            IsGaming = false;
            Save();
            GameUI.Instance.GameOver();
        }

        public void Save()
        {
            if (Score > TopScore)
            {
                TopScore = Score;
                IsNewRecord = true;
                PlayerPrefs.SetInt("TopScore", TopScore);
            }
        }

        public void Load()
        {
            TopScore = PlayerPrefs.GetInt("TopScore", 0);
        }
    }
}
