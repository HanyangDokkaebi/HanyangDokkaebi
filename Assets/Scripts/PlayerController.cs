using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveDirection;
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        Move();
    }

    private void Move()
    {
        //ÁÂ¿ìÀÌµ¿
        m_Rigidbody.velocity = new Vector2(moveDirection * speed, m_Rigidbody.velocity.y);
    }
}
