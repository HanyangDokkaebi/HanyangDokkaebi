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
            SceneManager.LoadScene("사냥터_지하수로");
        }
        else if (b == 2 && Input.GetKeyDown(KeyCode.LeftShift) && SystemMisstion.QuestNumber >= 10)
        {
            SceneManager.LoadScene("사냥터_폐선로");
        }
        else if (b == 3 && Input.GetKeyDown(KeyCode.LeftShift) && SystemMisstion.QuestNumber >= 20)
        {
            SceneManager.LoadScene("사냥터_경복궁 지하");
        }
        else if (b == 4 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene("도성");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("지하수로표지판"))
        {
            b = 1;
        }
        else if (collision.gameObject.CompareTag("폐선로표지판"))
        {
            b = 2;
        }
        else if (collision.gameObject.CompareTag("경복궁지하표지판"))
        {
            b = 3;
        }
        else if (collision.gameObject.CompareTag("도성표지판"))
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
