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
        // ���� �̵� ���� �޾ƿ���
        moveDirection = Input.GetAxisRaw("Horizontal");

        // �̵��ϰ�, ���� ��ȯ
        Move();
        FlipDirection();
    }

    private void Move()
    {
        // �¿� �̵�
        m_Rigidbody.velocity = new Vector2(moveDirection * speed, m_Rigidbody.velocity.y);
    }

    private void FlipDirection()
    {
        // �̵��ϴ� ���⿡ ���� ĳ���� ���� ��ȯ
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2); // ���������� �̵�
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // �������� �̵�
        }
    }
}
