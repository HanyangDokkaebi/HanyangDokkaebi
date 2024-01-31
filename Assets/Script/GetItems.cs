using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("¸¶³ª¿¡³ÊÁö"))
        {
            ItemManager.Energy += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("³ªºñ³¯°³"))
        {
            ItemManager.Monster_item_Butterfly += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("ÈíÇ÷±Í³¯°³"))
        {
            ItemManager.Monster_item_Vampire += 1;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("È£È¯°¡Á×"))
        {
            ItemManager.Monster_item_Tiger += 1;
            Destroy(collision.gameObject);

        }
    }
}
