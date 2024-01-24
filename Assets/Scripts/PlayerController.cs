using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : LivingEntity
{
    private Animator playerAnimator;
    private PlayerMovement playerMovement;

    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
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
        playerMovement.enabled = false;
    }
}
