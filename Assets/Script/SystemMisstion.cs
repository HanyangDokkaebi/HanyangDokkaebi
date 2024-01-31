using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SystemMisstion : MonoBehaviour
{

    //수주 전 0 / 진행중 1 / 퀘스트완료 -1
    int[] CurrnetQuest = new int[6] {0,0,0,0,0,0};

    public static int QuestNumber = 0;

    private string[] Missionlines =
    {
        //0
        "",

        //1
        "내무부로 이동하자.",

        //2
        "공방으로 이동하자.",

        //3
        "무기부품을 구해오자. \n태엽 0/20  기계부품 0/20",

        //4
        "주막으로 이동하자.",

        //5
        "선로에 있는 태엽괴물들을 처치하여 열쇠를 얻어내자. \n 열쇠 0/1",

        //6
        "산나비 30마리를 처치하자.",


    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Missionlines[QuestNumber];
    }
}
