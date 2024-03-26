using QFramework;
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
        public Color DefaultColor;

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
                ResetSelf();
                // 回收
                GameManager.Instance.FoodPoolRecycle(gameObject);

                // 让蛇变长
                GameManager.Instance.SnakeGrowUp();
            }
        }

        private void ResetSelf()
        {
            // 设置回默认值
            GetComponent<SpriteRenderer>().color = DefaultColor;
            FoodType = FoodType.Normal;
        }
    }
}
