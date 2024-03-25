using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeTest
{
    public class Food : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Snake"))
            {
                Destroy(gameObject);

                // »√…ﬂ±‰≥§
                GameManager.Instance.Snake.GrowUp();
            }
        }
    }
}
