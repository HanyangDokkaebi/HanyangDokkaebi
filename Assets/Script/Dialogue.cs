using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public AudioSource s;
    public static int index = 0;
    public GameObject SelectImage;
    public GameObject button;


    //��ȭ��. �ݺ��� �ϻ� ��ȭ�� ������ ��.
    private string[] lines
        = {
        //0
        "(������ ����� ������ ������ ���� �ٲ����. �� �������� �Ǳ��� ����� ������ ������ �ٽ��̷α���.)",
        
        //1
        "(�̹��� ū ����� ����ٰ� �ϴ� �����η� ���� ������ ����.)",

        //2
        "�Խ��ϴ�. �������̽ʴϱ�?",

        //�����η� �̵�
        //3
        "�������� �������־�� �� ����� �����.",

        //4
        "(�ɻ�ġ �ʾƺ��̴±�)",

        //5
        "���� ������ ������ �ҹ��� ���°� �˰� ��������.",

        //6
        "�ҹ� ���Դϱ�?",

        //7
        " ������� �ϳ��Ѿ� �������, ��𼱰� �νŰ����� �̷�����ٴ� �ҹ� ���̾�." 
        + "�̰� ������ �ν��� ��鸮�� �ִ���.",

        //8
        "���ϲ��� �ٽ��� ũ�ô�. ���ȴ뿡�� �� ����� �����ϰ� �ִ�����,"
        + "������ �̹��ؼ� ������ �� ����� �þ� �ذ����־����� ���ھ�.",

        //9
        "�˰ڽ��ϴ�. �ּ��� ���� ������ �Ը��ϰڽ��ϴ�.",


        //���Ǽҵ�1. ����� �߹��̶�� ���ڰ� �빮¦�ϰ� ����
        //10
        "(�ϴ� �������� ������� ������ ���߰ھ�."
        + "���� ������ ���� ���ķ� �ű���� �ڲ� ����� ���� ���� ���ϸ� �������°� �Ѽ����̴���.)",

        //�������� �̵�
        //11
        "����ʽÿ�. ������ �ʿ��Ͻʴϱ�?",

        //12
        "���� ����� ����� ���Ⱑ ���� ���Դٰ� �ؼ� �ԼҸ�..",

        //13
        "�� ȭ��� �����Ͻô°̴ϱ�?",

        //14
        "�׷��� �θ���?",

        //15
        "���ſ��� ���Ⱑ �վ������� �ӵ��� ���� �޶� ������ ���� �׸� �̸� �ٿ����ϴ�. �ٵ� �̸� ��¼����",

        //16
        "�������ּ�?",

        //17
        "�ֱٿ� ���ȴ뿡�� �뷮���� ���⸦ �ֹ��ؼ� ��ǰ�� ���ڸ��ϴ�. ���� ��ǰ�� ��������� ������ ���� �ɸ��ϴ�.",

        //18
        "(�̸� ��¼���� ���� ���� ���ƴٴϴ°� �����ϴ�. �׷��ٰ� ��ǰ�� ������ �� ��� ��ٸ� ���� ����.)"
        +"���� ����� ���ڼ�?",

        //19
        "�¿������� ��ǰ�̸� �𸣰�����.. �׳���� �ʹ� �����մϴ�. �ƽ����� ������ ���ֽ�����.",

        //20
        "�ƴϿ�. ���� ���ؿ���. �� �� ������ �ǰڼ�?",

        //21
        "���� �׷��ֽðڽ��ϱ�? �¿��� ����ǰ�� ���� 20������ ��ƿ��ֽŴٸ� �ݹ� �����帮�ڽ��ϴ�."
        + "���� ���� �����ϴ� �Ϲ� �˰� �Ϲ� ������ �帮�ڽ��ϴ�.",

        //22
        "�˰ڼ�.",

        //23
        "(����ǰ�̶� ������ ���� �ʴ� ���ο� ���� ã�� �� �ְ���.)",




    };      


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
    }

    int[] B_index = new int[14] {4,7,9,15,20,25,29,33,37,41,42,44,48,51}; //��ȭ���� ���� Ÿ�̹�
    int a = 0;
    public void Nextdialog()
    {
        s.Stop();
        if (textComponent.text == lines[index])
        {
            nextline();
        }
        else
        {
            
            a = 0;
            for (int i = 0; i < 14; i++)
                if (B_index[i] == index) //��ȭ���� ���� Ÿ�̹��̶��
                    a = 1;
            if (a == 1)
            {
                //�ε��� ����
                gameObject.SetActive(false); //������ �ϴ�
            }
            
            StopAllCoroutines();
            textComponent.text = lines[index];
        }

    }
    void StartDialogue()
    {
        s.Play();
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        s.Stop();
    }

    void nextline()
    {
        s.Play();
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
        }
        else
        {
            s.Stop();

            //����ٰ� ������ ���� ���ε�����
            //gameObject.SetActive(false);
       
        }

    }
}
