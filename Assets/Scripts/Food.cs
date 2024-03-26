using UnityEngine;

namespace SnakeTest
{
    public enum FoodType
    {
        Normal,
        BigScore,
    }

    public class Food : MonoBehaviour
    {
        public FoodType FoodType = FoodType.Normal;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Snake"))
            {
                switch (FoodType)
                {
                    case FoodType.Normal:
                        GameManager.Instance.Score.Value++;
                        break;
                    case FoodType.BigScore:
                        GameManager.Instance.Score.Value += 10;
                        break;
                    default:
                        break;
                }
                Destroy(gameObject);

                // »√…ﬂ±‰≥§
                GameManager.Instance.Snake.GrowUp();
            }
        }
    }
}
