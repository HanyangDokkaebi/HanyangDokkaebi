using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOn : MonoBehaviour
{
    public GameObject TextDialog;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 1 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("눌림");
            TextDialog.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("주막주인"))
        {
            a = 1;
        }
        else
        {
            a = 0;
        }
    }
}
