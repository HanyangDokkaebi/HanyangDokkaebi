using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
        Move();
        FlipDirection();

        // ���� �ִ��� üũ
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
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
}
