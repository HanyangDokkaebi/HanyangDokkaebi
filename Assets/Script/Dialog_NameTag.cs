using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog_NameTag : MonoBehaviour
{
    private string[] NameStrings =
  {
        //0
        "이영신",
    
        //1
        "이영신",

        //2
        "이영신",

        //퀘스트1 7개
        //3
        "이영신",

        //4
        "내부대신",

        //5
        "이영신",

        //6
        "내부대신",

        //7
        "이영신",

        //8
        "내부대신",

        //9
        "이영신",

        //퀘스트2 11개
        //10
        "이영신",

        //11
        "플레이어"

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
