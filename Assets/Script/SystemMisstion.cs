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
        "���δ���� ã�ư���.",

        //2
        "���������� ã�ư���.",

        //3
        "���尣���� �̵�����.",

        //4
        "������ ���� 0/30",

        //5
        "�������̿��� ���ư���.",

        //6
        "�������忡�� ���ư���.",

        //7
        "������ ��� 0/40",

        //8
        "�������忡�� ��������.",

        //9
        "�������̿��� ����.",

        //10
        "�곪�� ���� 0/25",

        //11
        "�������̿��� ���ư���",

        //12
        "���ȴ��忡�� ���ư���.",

        //13
        "�ָ����ο��� ����.",

        //14
        "�곪�� 0/30",

        //15
        "�ָ����ο��Է� ���ư���.",

        //16
        "���ȴ��忡�� ���ư���.",

        //17
        "�������ϸ� �����غ���.",

        //18
        "�������忡�� ���ư���.",

        //19
        "�������̿��� ����.",

        //20
        "ȣȯ���� 0/25",

        //21
        "�������̿��� ���ư���.",

        //22
        "���� ������ ū ���� ���ʶ߸���.",

        //23
        "�������ϸ� ��������.",

        //24
        "���踦 ã�ƶ�.",

        //25
        "������ �����߷���.",

        //26
        "�������忡�� ���ư���."


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
