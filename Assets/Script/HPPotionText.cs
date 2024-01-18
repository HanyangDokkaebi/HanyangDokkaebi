using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPPotionText : MonoBehaviour
{
    int HPpotion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HPpotion = ItemManager.HPPotion;
        GetComponent<TextMeshProUGUI>().text = "" + HPpotion;
    }
}
