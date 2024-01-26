using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : LivingEntity
{
    /*private Animator monsterAnimator;
    private MonsterMovement m_Movement;*/
    
    void Awake()
    {
        /* monsterAnimator = GetComponent<Animator>();
         m_Movement = GetComponent<MonsterMovement>();*/
        maxHp = 50f;
        atk = 5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        Debug.Log("Monster HP: " + hp);
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("Monster Dead!");
    }
}
