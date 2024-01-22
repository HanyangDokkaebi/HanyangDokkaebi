using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveDirection;
    private bool isGrounded;
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    public Transform groundCheck; // �� �� �ݶ��̴� ��ġ
    public float groundCheckRadius;
    public LayerMask groundLayer;

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

        // ���� �ִ��� üũ
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            m_Animator.SetBool("IsJumping", true);
            Jump();
        }
        else
        {
            m_Animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_Animator.SetTrigger("Attack_Sword");
            AttackSword();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            m_Animator.SetTrigger("Attack_Bow");
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
            transform.localScale = new Vector3(-2, 2, 2); // ������ �ٶ󺸱�
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(2, 2, 2); // ���� �ٶ󺸱�
        }
    }

    private void Jump()
    {
        m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, jumpForce);
    }

    private void AttackSword()
    {
        Debug.Log("AttackSword!");
    }

    private void AttackBow()
    {
        Debug.Log("AttackBow!");
    }
}
