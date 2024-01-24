using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class MonsterMovement : MonsterController
{
    //������Ʈ��
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    //���� �̵� ����
    public float speed;
    private float moveDirection = -1;
    //������ ���� �ǰݓ���
    public Transform pos;
    public Vector2 boxSize;
    //���� ��Ÿ�� ����
    private float curTime;
    public float cooldown = 0.5f;
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
            Attack();
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

    private void Attack()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            //Debug.Log(collider.tag);
            if (collider.tag == "Player")
            {
                m_Animator.SetTrigger("Attack");
                Debug.Log("MonsterAttack!");
                collider.GetComponent<PlayerMovement>().OnDamage(atk);
            }
        }
    }

    //Debug: ���ݹ��� �ð�ȭ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
