using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SnakeTest
{
    public class Snake : MonoBehaviour
    {
        public GameObject SnakeBodyPrefab;
        public List<GameObject> SnakeBodyList = new List<GameObject>();

        public float MoveTimeInterval = 1f;
        private float moveTimer;
        private Vector3 moveDir;

        private void Start()
        {
            moveDir = Vector3.up;
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
                moveDir = Vector3.right;
            if (horizontal < 0)
                moveDir = Vector3.left;
            if (vertical > 0)
                moveDir = Vector3.up;
            if (vertical < 0)
                moveDir = Vector3.down;
        }

        private void Move()
        {
            // 移动前，将当前位置给到更新的蛇身
            if (SnakeBodyList.Count > 0)
            {
                GameObject lastBody = SnakeBodyList.Last();
                SnakeBodyList.Remove(lastBody);
                lastBody.transform.position = transform.position;
                SnakeBodyList.Insert(0, lastBody);
            }

            // 移动
            transform.position += moveDir;
        }

        public void GrowUp()
        {
            GameObject bodyPrefab = Instantiate(SnakeBodyPrefab, new Vector3(1000, 1000, 0), Quaternion.identity);
            SnakeBodyList.Add(bodyPrefab);
        }
    }
}
