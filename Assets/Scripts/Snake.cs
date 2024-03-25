using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float MoveTimeInterval = 1f;
    private float moveTimer;
    private Vector3 currentDir;

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
        transform.position += currentDir;
    }
}
