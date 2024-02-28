using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DialogOn : MonoBehaviour
{
    public GameObject TextDialog;
    public GameObject Store;
    int a = 0;
    public static int b = 0;

    // Update is called once per frame
    void Update()
    {
        if (a == 1 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("눌림");
            TextDialog.SetActive(true);
        }
        else if (a == 2 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("눌림");
            TextDialog.SetActive(true);
        }
        else if (a == 3 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("눌림");
            TextDialog.SetActive(true);
        }
        else if (a == 4 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("눌림");
            //TextDialog.SetActive(true);
            Store.SetActive(true);
        }
        else if (a == 5 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("눌림");
            TextDialog.SetActive(true);
        }
        else if (a == 6 && b == 0)
        {
            b = 1;
            TextDialog.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        주막주인 1
        보안대장 2
        내부대신 3
        포션판매원 4
        대장장이 5
         */
        if (collision.gameObject.CompareTag("주막주인"))
        {
            a = 1;
        }
        else if (collision.gameObject.CompareTag("보안대장"))
        {
            a = 2;
        }
        else if (collision.gameObject.CompareTag("내부대신"))
        {
            a = 3;
        }
        else if (collision.gameObject.CompareTag("포션판매원"))
        {
            a = 4;
        }
        else if (collision.gameObject.CompareTag("대장장이"))
        {
            a = 5;
        }
        else if (collision.gameObject.CompareTag("초기화용"))
        {
            a = 0;
        }
        else if (collision.gameObject.CompareTag("시작텍스트"))
        {
            a = 6;
            
        }
    }
}
