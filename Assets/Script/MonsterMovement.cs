using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class MonsterMovement : MonsterController
{
    //������Ʈ��
    private Rigidbody2D monsterRigidbody;
    private Animator monsterAnimator;
    //���� �̵� ����
    public float speed;
    private float moveDirection = -1;
    //������ ���� �ǰݹ���
    public Transform pos;
    public Vector2 boxSize;
    //���� ��Ÿ�� ����
    private float curTime = 0;
    public float cooldown = 2.0f;
    //���� ����
    private bool isAttacking = false;

    private void Awake()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        monsterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        if (!isDead)
        {
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Player" /* && Gamemanager.isGameOver == false */)   //���ݹ����� �÷��̾ ������ ���
                {
                    if (curTime <= 0)   //��Ÿ���� �� ����
                    {
                        Attack(collider);
                        curTime = cooldown; //��Ÿ�� �ٽ� ������
                    }
                    else
                    {
                        curTime -= Time.deltaTime;
                    }
                }
            }
            if (!isAttacking)
            {
                Move();
            }
        }
        else
        {
            monsterAnimator.SetTrigger("Die");
            Destroy(gameObject, 2.0f);
        }
    }

    private void Move()
    {
        monsterAnimator.SetBool("IsMoving", true);
        monsterRigidbody.velocity = new Vector2(moveDirection * speed, monsterRigidbody.velocity.y);
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

    private void Attack(Collider2D collider)
    {
        isAttacking = true;
        monsterRigidbody.velocity = new Vector2(0, 0);  //������ �� ���缭
        monsterAnimator.SetTrigger("Attack");
        Debug.Log("MonsterAttack!");
        collider.GetComponent<PlayerMovement>().OnDamage(atk);
    }

    public void ResetAttack()
    {
        isAttacking = false;
        Debug.Log("ResetAttack");
    }

    //Debug: ���ݹ��� �ð�ȭ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
