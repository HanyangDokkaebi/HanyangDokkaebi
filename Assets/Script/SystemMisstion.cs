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
        "내부대신을 찾아가자.",

        //2
        "방위대장을 찾아가자.",

        //3
        "대장간으로 이동하자.",

        //4
        "흡혈귀 날개 0/30",

        //5
        "대장장이에게 돌아가자.",

        //6
        "방위대장에게 돌아가자.",

        //7
        "흡혈귀 토벌 0/40",

        //8
        "방위대장에게 보고하자.",

        //9
        "대장장이에게 가자.",

        //10
        "산나비 날개 0/25",

        //11
        "대장장이에게 돌아가자",

        //12
        "보안대장에게 돌아가자.",

        //13
        "주막주인에게 가자.",

        //14
        "산나비 0/30",

        //15
        "주막주인에게로 돌아가자.",

        //16
        "보안대장에게 돌아가자.",

        //17
        "도성지하를 조사해보자.",

        //18
        "방위대장에게 돌아가자.",

        //19
        "대장장이에게 가자.",

        //20
        "호환가죽 0/25",

        //21
        "대장장이에게 돌아가자.",

        //22
        "도성 지하의 큰 돌을 무너뜨리자.",

        //23
        "도성지하를 조사하자.",

        //24
        "열쇠를 찾아라.",

        //25
        "도깨비를 쓰러뜨려라.",

        //26
        "방위대장에게 돌아가자."


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
