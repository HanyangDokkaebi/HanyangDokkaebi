using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterMovement : MonsterController
{
    public float speed;
    private Rigidbody2D m_Rigidbody;
    private float moveDirection = -1;
    private Animator m_Animator;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            Move();
        }
        else
        {
            m_Animator.SetTrigger("Die");
            Destroy(gameObject, 2.0f);
        }
    }

    private void Move()
    {
        m_Animator.SetBool("IsMoving", true);
        m_Rigidbody.velocity = new Vector2(moveDirection * speed, m_Rigidbody.velocity.y);
    }

    //���� ������ ���� ��ȯ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            //Debug.Log("WALL!");
            moveDirection *= -1;
            FlipDirection();
        }
    }

    //���� ��ȯ
    private void FlipDirection()
    {
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2); // ������ �ٶ󺸱�
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // ���� �ٶ󺸱�
        }
    }
}
