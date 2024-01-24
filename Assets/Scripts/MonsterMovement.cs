using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class MonsterMovement : MonsterController
{
    //컴포넌트들
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    //몬스터 이동 세팅
    public float speed;
    private float moveDirection = -1;
    //공격을 위한 피격볌위
    public Transform pos;
    public Vector2 boxSize;
    //공격 쿨타임 조정
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

    //벽에 닿으면 방향 전환
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            //Debug.Log("WALL!");
            moveDirection *= -1;
            FlipDirection();
        }
    }

    //방향 전환
    private void FlipDirection()
    {
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(-2, 2, 2); // 오른쪽 바라보기
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // 왼쪽 바라보기
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

    //Debug: 공격범위 시각화
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
