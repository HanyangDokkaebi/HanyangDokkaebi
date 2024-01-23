using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController {
    //플레이어 이동 관련 변수
    public float speed;
    public float jumpForce;
    private float moveDirection;

    //플레이어에 붙어있는 컴포넌트들
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;

    //점프 시 땅에 붙어있는지 판정
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    //공격을 위한 피격범위
    public Transform pos;
    public Vector2 boxSize;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        if(moveDirection == 0)
        {
            m_Animator.SetBool("IsMoving", false);      
        }
        if(moveDirection != 0)
        {
            m_Animator.SetBool("IsMoving", true);
        }
        Move();
        FlipDirection();

        // 땅에 있는지 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackSword();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            AttackBow();
        }
    }

    private void Move()
    {
        m_Rigidbody.velocity = new Vector2(moveDirection * speed, m_Rigidbody.velocity.y);
    }

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

    private void Jump()
    {
        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, jumpForce);
    }

    private void AttackSword()
    {
        m_Animator.SetTrigger("Attack_Sword");
        Debug.Log("AttackSword!");
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            //Debug.Log(collider.tag);
            if(collider.tag == "Monster")
            {
                collider.GetComponent<MonsterMovement>().OnDamage(atk);
            }
        }
    }

    private void AttackBow()
    {
        m_Animator.SetTrigger("Attack_Bow");
        Debug.Log("AttackBow!");
    }

    //Debug: 공격범위 시각화
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
