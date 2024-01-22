using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : SpawnArrow
{
    public float speed = 10f;
    private Rigidbody2D m_arrowRigidbody;

    void Start()
    {
        m_arrowRigidbody = GetComponent<Rigidbody2D>();
        m_arrowRigidbody.velocity = Vector2.left * speed;

        Destroy(gameObject, 0.3f);
    }
}
