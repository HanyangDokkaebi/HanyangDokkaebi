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
        "����Ʈ\n-------------\n�����η� �̵�����.",

        //1
        "����Ʈ\n-------------\n�������� �̵�����.",

        //2
        "����Ʈ\n-------------\n�����ǰ�� ���ؿ���. \n�¿� 0/20  ����ǰ 0/20",

        //3

        "����Ʈ\n-------------\n�ָ����� �̵�����.",

        //4
        "����Ʈ\n-------------\n���ο� �ִ� �¿��������� óġ�Ͽ� ���踦 ����. \n ���� 0/1",

        //5
        "����Ʈ\n-------------\n�곪�� 30������ óġ����.",


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
