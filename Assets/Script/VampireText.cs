using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VampireText : MonoBehaviour
{
    void Update()
    {

        GetComponent<TextMeshProUGUI>().text = "" + ItemManager.Monster_item_Vampire;
    }
}
