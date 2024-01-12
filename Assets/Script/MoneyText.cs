using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    int money = 0;
    void Update()
    {
        money = ItemManager.Money;
        GetComponent<TextMeshProUGUI>().text = "" + money;
    }
}
