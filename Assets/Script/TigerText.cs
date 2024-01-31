using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TigerText : MonoBehaviour
{
    void Update()
    {

        GetComponent<TextMeshProUGUI>().text = "" + ItemManager.Monster_item_Tiger;
    }
}
