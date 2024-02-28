using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject CurrentQuest;
    public GameObject Store;
    // Update is called once per frame
    public void StoreOff()
    {
        Store.SetActive(false);
    }
    public void HPpotionUp()
    {
        if (ItemManager.Money >= 1000)
        {
            ItemManager.Money -= 1000;
            ItemManager.HPPotion += 1;
        }
    }
    public void ManapotionUp()
    {
        if (ItemManager.Money >= 500 && ItemManager.Energy >= 3)
        {
            ItemManager.Money -= 500;
            ItemManager.Energy -= 3;
            ItemManager.ManaPotion += 1;
        }
    }
    public void inventoryOn()
    {
        if (Inventory.activeSelf)
        {
            Time.timeScale = 1f;
            Inventory.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            Inventory.SetActive(true);
        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("도성");
    }

    private PlayerController scriptInstance;
    private void Start()
    {
        GameObject script1Object = GameObject.Find("Player"); // Script1을 가진 게임 오브젝트의 이름을 넣어주세요
        scriptInstance = script1Object.GetComponent<PlayerController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && ItemManager.HPPotion != 0 && PlayerController.SThp != PlayerController.STmaxHp)
        {
            if (scriptInstance != null)
            {
                scriptInstance.hpUP();
            }
            ItemManager.HPPotion -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && ItemManager.ManaPotion != 0 && PlayerController.STmana!= PlayerController.STmaxMana)
        {
            HPBar.Mana += 10;
            ItemManager.ManaPotion -= 1;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryOn();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (CurrentQuest.activeSelf)
            {
                Time.timeScale = 1f;
                CurrentQuest.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                CurrentQuest.SetActive(true);
            }
        }
    }
}
