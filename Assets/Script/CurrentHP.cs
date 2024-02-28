using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CurrentHP : MonoBehaviour
{
    float CurrentHp = 0;
    // Update is called once per frame
    void Update()
    {
        CurrentHp = PlayerController.SThp;
        GetComponent<TextMeshProUGUI>().text = CurrentHp.ToString();
    }
}
