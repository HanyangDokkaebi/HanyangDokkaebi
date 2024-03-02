using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float maxHp = 100f;
    public float atk = 10f;
    public float def;
    public float hp { get; protected set; }
    public bool isDead { get; protected set; }

    //임시 마나
    public static float maxMana = 100f;
    public static float mana = 100f;

    protected virtual void OnEnable()
    {
        isDead = false;
        hp = maxHp;
    }

    public virtual void OnDamage(float damage)
    {
        hp -= damage;

        if(hp <= 0 && !isDead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }
}
