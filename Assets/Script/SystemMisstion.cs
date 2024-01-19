using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SystemMisstion : MonoBehaviour
{
    private string[] Missionlines =
    {
        //1
        "퀘스트\n-------------\n주막주인을 찾아가시오."


    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Missionlines[GameManager.QuestNumber];
    }
}
