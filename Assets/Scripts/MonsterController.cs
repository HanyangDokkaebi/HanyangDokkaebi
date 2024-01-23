using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : LivingEntity
{
    /*private Animator m_Animator;
    private MonsterMovement m_Movement;*/

    void Awake()
    {
       /* m_Animator = GetComponent<Animator>();
        m_Movement = GetComponent<MonsterMovement>();*/
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
