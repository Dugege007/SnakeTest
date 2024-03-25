using System.Collections;
using System.Collections.Generic;
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
                        GameManager.Instance.Score++;
                        break;
                    case FoodType.BigScore:
                        GameManager.Instance.Score += 10;
                        GameManager.Instance.Snake.SpeedUp();
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
