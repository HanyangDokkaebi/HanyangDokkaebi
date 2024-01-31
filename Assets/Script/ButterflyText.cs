using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ButterflyText : MonoBehaviour
{
    void Update()
    {

        GetComponent<TextMeshProUGUI>().text = "" + ItemManager.Monster_item_Butterfly;
    }
}
