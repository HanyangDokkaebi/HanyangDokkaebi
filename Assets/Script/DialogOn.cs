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
            //Debug.Log("����");
            TextDialog.SetActive(true);
        }
        else if (a == 2 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("����");
            TextDialog.SetActive(true);
        }
        else if (a == 3 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("����");
            TextDialog.SetActive(true);
        }
        else if (a == 4 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("����");
            //TextDialog.SetActive(true);
            Store.SetActive(true);
        }
        else if (a == 5 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("����");
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
        �ָ����� 1
        ���ȴ��� 2
        ���δ�� 3
        �����Ǹſ� 4
        �������� 5
         */
        if (collision.gameObject.CompareTag("�ָ�����"))
        {
            a = 1;
        }
        else if (collision.gameObject.CompareTag("���ȴ���"))
        {
            a = 2;
        }
        else if (collision.gameObject.CompareTag("���δ��"))
        {
            a = 3;
        }
        else if (collision.gameObject.CompareTag("�����Ǹſ�"))
        {
            a = 4;
        }
        else if (collision.gameObject.CompareTag("��������"))
        {
            a = 5;
        }
        else if (collision.gameObject.CompareTag("�ʱ�ȭ��"))
        {
            a = 0;
        }
        else if (collision.gameObject.CompareTag("�����ؽ�Ʈ"))
        {
            a = 6;
            
        }
    }
}
