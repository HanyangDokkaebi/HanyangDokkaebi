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
        "����Ʈ\n-------------\n�ָ������� ã�ư��ÿ�."


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
