using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : PlayerController {
    //�÷��̾� �̵� ���� ����
    public float speed;
    public float jumpForce;
    public static float moveDirection;

    //�÷��̾ �پ��ִ� ������Ʈ��
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;

    //���� �� ���� �پ��ִ��� ����
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public GameObject arrow;
    public Transform arrowPos;

    //������ ���� �ǰݹ���
    public Transform pos;
    public Vector2 boxSize;

    //�⺻���� ��Ÿ��
    private float curTimeSword = 0;
    public float cooldownSword = 0.5f;

    //ȭ����� ���� ����
    private float curTimeBow = 0;
    public float cooldownBow = 0.5f;
    public float arrowSpeed = 10.0f;
    public float arrowLifetime = 0.5f;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
        {
            playerAnimator.SetBool("Die", true);
            return;
        }
        moveDirection = Input.GetAxisRaw("Horizontal");
        if(moveDirection == 0)
        {
            playerAnimator.SetBool("IsMoving", false);      
        }
        if(moveDirection != 0)
        {
            playerAnimator.SetBool("IsMoving", true);
        }
        Move();
        FlipDirection();

        // ���� �ִ��� üũ
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (curTimeSword <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                AttackSword();
                curTimeSword = cooldownSword;
            }
        }
        else
        {
            curTimeSword -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (curTimeBow <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                AttackBow();
                curTimeBow = cooldownBow;
            }
        }
        else
        {
            curTimeBow -= Time.deltaTime;
        }
    }

    private void Move()
    {
        playerRigidbody.velocity = new Vector2(moveDirection * speed, playerRigidbody.velocity.y);
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
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
    }

    private void AttackSword()
    {
        playerAnimator.SetTrigger("Attack_Sword");
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
        playerAnimator.SetTrigger("Attack_Bow");
        Debug.Log("AttackBow!");
    }

    //�ִϸ��̼� �̺�Ʈ �׼����� ����
    private void SpawnArrow()
    {
        GameObject arrowClone;

        arrowClone = Instantiate(arrow, arrowPos.transform);
        arrowClone.transform.parent = null;

        Rigidbody2D arrowRigidbody2d = arrowClone.GetComponent<Rigidbody2D>();
        Collider2D arrowCollider2d = arrowClone.GetComponent<Collider2D>();

        /*if(arrowRigidbody2d == null) Debug.Log("arrowRigidbody2d is null");
        if(arrowCollider2d == null) Debug.Log("arrowCollider2d is null");*/

        Destroy(arrowClone, arrowLifetime);

        if(transform.localScale.x > 0)
        {
            arrowRigidbody2d.velocity = arrowSpeed * Vector2.left;
        }
        else
        {
            arrowRigidbody2d.velocity = arrowSpeed * Vector2.right;
        }

        /*Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(arrowClone.transform.position, arrowCollider2d.bounds.size, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            //Debug.Log(collider.tag);
            if (collider.tag == "Monster")
            {
                Debug.Log("Arrow Hit!");
                collider.GetComponent<MonsterMovement>().OnDamage(atk * 0.5f);
            }
        }*/
    }

    //Debug: ���ݹ��� �ð�ȭ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
