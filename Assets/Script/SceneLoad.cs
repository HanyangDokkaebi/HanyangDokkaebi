using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    int b = 0;

    // Update is called once per frame
    void Update()
    {
        if (b == 1 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene("�����_���ϼ���");
        }
        else if (b == 2 && Input.GetKeyDown(KeyCode.LeftShift) && SystemMisstion.QuestNumber >= 10)
        {
            SceneManager.LoadScene("�����_�󼱷�");
        }
        else if (b == 3 && Input.GetKeyDown(KeyCode.LeftShift) && SystemMisstion.QuestNumber >= 20)
        {
            SceneManager.LoadScene("�����_�溹�� ����");
        }
        else if (b == 4 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene("����");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("���ϼ���ǥ����"))
        {
            b = 1;
        }
        else if (collision.gameObject.CompareTag("�󼱷�ǥ����"))
        {
            b = 2;
        }
        else if (collision.gameObject.CompareTag("�溹������ǥ����"))
        {
            b = 3;
        }
        else if (collision.gameObject.CompareTag("����ǥ����"))
        {
            //Debug.Log("Ekgdma");
            b = 4;
        }
        else
        {
            b = 0;
        }
    }
}
