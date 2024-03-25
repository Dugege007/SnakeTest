using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeTest
{
    public class Snake : MonoBehaviour
    {
        public GameObject SnakeBodyPrefab;
        public Queue<GameObject> SnakeBodyQueue = new Queue<GameObject>();

        public float MoveTimeInterval = 1f;
        private float moveTimer;
        private Vector3 currentDir;

        private void Start()
        {
            currentDir = Vector3.up;
        }

        private void Update()
        {
            moveTimer += Time.deltaTime;

            SwitchDir();

            if (moveTimer > MoveTimeInterval)
            {
                Move();
                moveTimer = 0;
            }
        }

        private void SwitchDir()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal > 0)
                currentDir = Vector3.right;
            if (horizontal < 0)
                currentDir = Vector3.left;
            if (vertical > 0)
                currentDir = Vector3.up;
            if (vertical < 0)
                currentDir = Vector3.down;
        }

        private void Move()
        {
            // 移动前，将当前位置给到更新的蛇身
            if (SnakeBodyQueue.Count > 0)
            {
                GameObject lastBody = SnakeBodyQueue.Dequeue();
                lastBody.transform.position = transform.position;
                SnakeBodyQueue.Enqueue(lastBody);
            }

            // 移动
            transform.position += currentDir;
        }

        private void GrowUp()
        {
            GameObject bodyPrefab = Instantiate(SnakeBodyPrefab, new Vector3(1000, 1000, 0), Quaternion.identity);
            bodyPrefab.transform.parent = transform;
            SnakeBodyQueue.Enqueue(bodyPrefab);
        }
    }
}
