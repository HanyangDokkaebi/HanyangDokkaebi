using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SystemMisstion : MonoBehaviour
{

    //���� �� 0 / ������ 1 / ����Ʈ�Ϸ� -1
    int[] CurrnetQuest = new int[6] {0,0,0,0,0,0};

    public static int QuestNumber = 0;

    private string[] Missionlines =
    {
        //0
        "",

        //1
        "�����η� �̵�����.",

        //2
        "�������� �̵�����.",

        //3
        "�����ǰ�� ���ؿ���. \n�¿� 0/20  ����ǰ 0/20",

        //4
        "�ָ����� �̵�����.",

        //5
        "���ο� �ִ� �¿��������� óġ�Ͽ� ���踦 ����. \n ���� 0/1",

        //6
        "�곪�� 30������ óġ����.",


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
