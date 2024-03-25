using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SnakeTest
{
    public class Snake : MonoBehaviour
    {
        public GameObject SnakeBodyPrefab;
        public List<GameObject> SnakeBodyList = new List<GameObject>();

        public float MoveSpeed = 1.8f;
        private float moveTimer;
        private Vector3 moveDir;
        private float currentMoveSpeed;

        private bool isPressingMoveKey = false;
        private float readyTimer;
        public float StartSpeedUpTime = 0.8f;

        private void Start()
        {
            moveDir = Vector3.up;
            currentMoveSpeed = MoveSpeed;
        }

        private void Update()
        {
            // ��ʱ
            moveTimer += Time.deltaTime;
            if (isPressingMoveKey)
                readyTimer += Time.deltaTime;

            // ת��
            SwitchDir();

            // ���°���
            if (Input.GetKeyDown(KeyCode.W)
                || Input.GetKeyDown(KeyCode.A)
                || Input.GetKeyDown(KeyCode.S)
                || Input.GetKeyDown(KeyCode.D))
            {
                Move();
                moveTimer = 0;
                isPressingMoveKey = true;
            }

            // ����
            if (readyTimer > StartSpeedUpTime)
                currentMoveSpeed = MoveSpeed * 2f;

            // ̧�𰴼�
            if (Input.GetKeyUp(KeyCode.W)
                || Input.GetKeyUp(KeyCode.A)
                || Input.GetKeyUp(KeyCode.S)
                || Input.GetKeyUp(KeyCode.D))
            {
                isPressingMoveKey = false;
                currentMoveSpeed = MoveSpeed;
                readyTimer = 0;
            }

            // ���ʱ���ƶ�
            if (moveTimer > 1f / currentMoveSpeed)
            {
                if (GameManager.Instance.IsGaming)
                {
                    Move();
                    moveTimer = 0;
                }
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
            // �ƶ�ǰ������ǰλ�ø������µ�����
            if (SnakeBodyList.Count > 0)
            {
                GameObject lastBody = SnakeBodyList.Last();
                SnakeBodyList.Remove(lastBody);
                lastBody.transform.position = transform.position;
                SnakeBodyList.Insert(0, lastBody);
            }

            // �ƶ�
            transform.position += moveDir;
            transform.up = moveDir;
        }

        public void GrowUp()
        {
            GameObject bodyPrefab = Instantiate(SnakeBodyPrefab, new Vector3(1000, 1000, 0), Quaternion.identity);
            SnakeBodyList.Add(bodyPrefab);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("SnakeBody"))
            {
                // ��Ϸ����
                GameManager.Instance.GameOver();
            }

            if (collision.gameObject.CompareTag("Wall"))
            {
                // ��Ϸ����
                GameManager.Instance.GameOver();
            }
        }
    }
}
