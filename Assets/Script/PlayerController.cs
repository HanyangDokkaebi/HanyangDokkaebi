using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : LivingEntity
{
    void Awake()
    {

    }

    void Update()
    {
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        Debug.Log("Player HP: " + hp);
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("Player Dead!");
    }
}
