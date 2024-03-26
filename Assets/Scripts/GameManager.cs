using QFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakeTest
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private Snake snake;
        public bool IsGaming = true;

        private FoodSpawner foodSpawner;

        public BindableProperty<int> Score = new(0);
        public BindableProperty<int> FoodCount = new(0);
        public BindableProperty<int> Level = new(1);
        public int TopScore = 0;
        public bool IsNewRecord = false;

        private bool needSpeedUp = false;

        protected override void Awake()
        {
            base.Awake();

            Load();

            if (snake == null)
                snake = GameObject.FindGameObjectWithTag("Snake").GetComponent<Snake>();

            if (foodSpawner == null)
                foodSpawner = GameObject.Find("FoodSpawner").GetComponent<FoodSpawner>();
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

            if (needSpeedUp)
            {
                snake.SpeedUp();
                needSpeedUp = false;
            }
        }

        public void SnakeGrowUp()
        {
            snake.GrowUp();
        }

        public bool CheckOnSnakeBody(Vector3 pos)
        {
            foreach (var body in snake.SnakeBodyList)
            {
                if (Vector3.Distance(pos, body.transform.position) < 0.1f)
                {
                    return false;
                }
            }

            return true;
        }

        public void FoodPoolRecycle(GameObject obj)
        {
            // 回收
            foodSpawner.Recycle(obj);
            // 生成
            foodSpawner.SpawnFood();
        }

        public void GameOver()
        {
            IsGaming = false;
            Save();
            GameUI.Instance.GameOver();
        }

        public void Save()
        {
            TopScore = Score.Value;
            IsNewRecord = true;
            PlayerPrefs.SetInt("TopScore", TopScore);
        }

        public void Load()
        {
            TopScore = PlayerPrefs.GetInt("TopScore", 0);
        }
    }
}
