using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class MonsterMovement : MonsterController
{
    //컴포넌트들
    private Rigidbody2D monsterRigidbody;
    //private Animator monsterAnimator;
    //몬스터 이동 세팅
    public float speed;
    private float moveDirection = -1;
    //공격을 위한 피격범위
    public Transform pos;
    public Vector2 boxSize;
    //공격 쿨타임 조정
    private float curTime = 0;
    public float cooldown = 2.0f;
    //몬스터 상태
    private bool isAttacking = false;
    public float initHp;
    public float initAtk;
    private void Awake()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        monsterAnimator = GetComponent<Animator>();
        maxHp = initHp;
        hp = maxHp;
        atk = initAtk;
    }

    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        if (!isDead)
        {
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Player" /* && Gamemanager.isGameOver == false */)   //공격범위에 플레이어가 존재할 경우
                {
                    if (curTime <= 0)   //쿨타임이 다 돌면
                    {
                        Attack(collider);
                        curTime = cooldown; //쿨타임 다시 돌리기
                    }
                    else
                    {
                        curTime -= Time.deltaTime;
                    }
                }
            }
            if (!isAttacking && monsterAnimator.GetCurrentAnimatorStateInfo(0).IsName("3_Debuff_Stun 1") == false)
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
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z); //방향 전환
    }

    private void Attack(Collider2D collider)
    {
        isAttacking = true;
        monsterRigidbody.velocity = new Vector2(0, 0);  //공격할 땐 멈춰서
        monsterAnimator.SetTrigger("Attack");
        Debug.Log("MonsterAttack!");
        collider.GetComponent<PlayerMovement>().OnDamage(atk);
    }

    public void ResetAttack()
    {
        isAttacking = false;
        Debug.Log("ResetAttack");
    }

    //Debug: 공격범위 시각화
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
