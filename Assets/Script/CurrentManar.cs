using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CurrentManar : MonoBehaviour
{
    float currentManar = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentManar = PlayerController.STmana;
        GetComponent<TextMeshProUGUI>().text = currentManar.ToString();
    }
}
