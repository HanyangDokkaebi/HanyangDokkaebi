using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            Debug.Log("Arrow hit!");
            collision.GetComponent<MonsterMovement>().OnDamage(LivingEntity.atk * 0.5f);
            Destroy(gameObject);
        }
    }
}
