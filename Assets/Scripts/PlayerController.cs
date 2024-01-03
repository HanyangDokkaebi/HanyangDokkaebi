using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveDirection;
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 현재 이동 방향 받아오기
        moveDirection = Input.GetAxisRaw("Horizontal");

        // 이동하고, 방향 전환
        Move();
        FlipDirection();
    }

    private void Move()
    {
        // 좌우 이동
        m_Rigidbody.velocity = new Vector2(moveDirection * speed, m_Rigidbody.velocity.y);
    }

    private void FlipDirection()
    {
        // 이동하는 방향에 따라 캐릭터 방향 전환
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2); // 오른쪽으로 이동
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // 왼쪽으로 이동
        }
    }
}
