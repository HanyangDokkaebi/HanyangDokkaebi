using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaPotionText : MonoBehaviour
{
    int energey;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        energey = ItemManager.ManaPotion;
        GetComponent<TextMeshProUGUI>().text = "" + energey;
    }
}
