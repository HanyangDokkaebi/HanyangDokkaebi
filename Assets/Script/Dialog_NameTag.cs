using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog_NameTag : MonoBehaviour
{
    private string[] NameStrings =
  {
        //0
        "�̿���",
    
        //1
        "�̿���",

        //2
        "�̿���",

        //����Ʈ1 7��
        //3
        "�̿���",

        //4
        "���δ��",

        //5
        "�̿���",

        //6
        "���δ��",

        //7
        "�̿���",

        //8
        "���δ��",

        //9
        "�̿���",

        //����Ʈ2 11��
        //10
        "�̿���",

        //11
        "�÷��̾�"

    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = NameStrings[Dialogue.index];
    }
}
