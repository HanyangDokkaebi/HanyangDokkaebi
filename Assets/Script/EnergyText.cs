using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyText : MonoBehaviour
{
    int energy = 0;
    void Update()
    {
        energy = ItemManager.Energy;
        GetComponent<TextMeshProUGUI>().text = "" + energy;
    }
}
