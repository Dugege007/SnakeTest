using UnityEngine;

namespace SnakeTest
{
    // ��ǰ��Ļ��Χ
    // ���£�-11, 11��
    // ���ң�-20, 20��
    public class FoodSpawner : MonoBehaviour
    {
        public GameObject FoodPrefab;
        private GameObject currentFood;

        private void Start()
        {
            currentFood = Instantiate(FoodPrefab, new Vector3(0, 5f, 0), Quaternion.identity);
        }

        private void Update()
        {
            if (currentFood == null)
            {
                int randomX = Random.Range(-20, 21);
                int randomY = Random.Range(-11, 12);
                Vector3 randomPos = new Vector3(randomX, randomY, 0);
                currentFood = Instantiate(FoodPrefab, randomPos, Quaternion.identity);

                if (Random.Range(0, 1f) < 0.1f)
                {
                    currentFood.GetComponent<Renderer>().material.color = Color.red;
                    currentFood.GetComponent<Food>().FoodType = FoodType.BigScore;
                }
            }
        }
    }
}
