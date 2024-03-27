using QFramework;
using UnityEngine;

namespace SnakeTest
{
    // ��ǰ��Ļ��Χ
    // ���£�-11, 11��
    // ���ң�-20, 20��
    public class FoodSpawner : MonoBehaviour
    {
        public GameObject FoodPrefab;
        private SimpleObjectPool<GameObject> foodPool;
        private GameObject currentFood;

        private void Start()
        {
            foodPool = new SimpleObjectPool<GameObject>(() =>
            {
                var foodObj = Instantiate(FoodPrefab, new Vector3(0, 5f, 0), Quaternion.identity);
                foodObj.Hide();
                return foodObj;
            },
            gameObj => { gameObj.Hide(); }, 3);

            GameManager.Instance.Level.RegisterWithInitValue(level =>
            {
                if (level == 1 || level == 10 || level == 30)
                {
                    SpawnFood();
                }

            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        public void SpawnFood()
        {
            while (true)
            {
                int randomX = Random.Range(-20, 21);
                int randomY = Random.Range(-11, 12);
                Vector3 randomPos = new Vector3(randomX, randomY, 0);

                if (GameManager.Instance.CheckOnSnakeBody(randomPos))
                {
                    // ����
                    currentFood = foodPool.Allocate();
                    // ����λ�ò���ʾ
                    currentFood.Position(randomPos)
                        .Show();

                    // һ�����ʱ�ɴ��
                    if (Random.Range(0, 1f) < 0.1f)
                    {
                        currentFood.GetComponent<SpriteRenderer>().color = Color.red;
                        currentFood.GetComponent<Food>().FoodType = FoodType.BigScore;
                    }

                    break;
                }
            }
        }

        public void Recycle(GameObject obj)
        {
            foodPool.Recycle(obj);
        }
    }
}
