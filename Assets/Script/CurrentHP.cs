using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CurrentHP : MonoBehaviour
{
    float CurrentHp = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHp = HPBar.HP;
        GetComponent<TextMeshProUGUI>().text = CurrentHp.ToString();
    }
}