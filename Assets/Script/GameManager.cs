using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ItemManager.HPPotion != 0 && HPBar.HP != HPBar.MaxHp)
        {
            HPBar.HP += 10;
            ItemManager.HPPotion -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && ItemManager.ManaPotion != 0 && HPBar.Mana != HPBar.MaxMana)
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
