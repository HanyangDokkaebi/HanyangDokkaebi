using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : LivingEntity
{
    public static float STmaxHp = 100f;
    public static float SThp { get; protected set; }
    public static float STmaxMana = 100f;
    public static float STmana = 100f;
    void Awake()
    {

    }

    void Update()
    {
        STmaxHp = maxHp;
        SThp = hp;
        STmaxMana = maxMana;
        STmana = mana;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        SThp = hp;
        Debug.Log("Player STHP: " + SThp);
        Debug.Log("Player HP: " + hp);
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("Player Dead!");
    }

    public void hpUP()
    {
        hp += 10;
    }
}
