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


    //대화집. 반복적 일상 대화는 밑으로 뺌.
    private string[] lines
        = {
        //0
        "(서양의 기술이 들어오고 조선이 많이 바뀌었다. 이 어지러운 판국에 사건이 끊이지 않으니 근심이로구나.)",
        
        //1
        "(이번에 큰 사건이 생겼다고 하니 내무부로 가서 경위를 들어보자.)",

        //2
        "왔습니다. 무슨일이십니까?",

        //내무부로 이동
        //3
        "…협판이 조사해주어야 할 사건이 생겼다.",

        //4
        "(심상치 않아보이는군)",

        //5
        "요즘 도성에 흉흉한 소문이 도는건 알고 있을테지.",

        //6
        "소문 말입니까?",

        //7
        " 사람들이 하나둘씩 사라지고, 어디선가 인신공양이 이루어진다는 소문 말이야." 
        + "이것 때문에 민심이 흔들리고 있다지.",

        //8
        "전하께서 근심이 크시다. 보안대에서 이 사건을 조사하고 있다지만,"
        + "성과가 미미해서 협판이 이 사건을 맡아 해결해주었으면 좋겠어.",

        //9
        "알겠습니다. 최선을 다해 진상을 규명하겠습니다.",


        //에피소드1. 사건의 발발이라는 글자가 대문짝하게 찍힘
        //10
        "(일단 공방으로 무기부터 받으러 가야겠어."
        + "서양 문물이 들어온 이후로 신기술이 자꾸 생기니 제때 정비를 안하면 뒤쳐지는건 한순간이더군.)",

        //공방으로 이동
        //11
        "어서오십시오. 무엇이 필요하십니까?",

        //12
        "서양 기술이 접목된 무기가 새로 나왔다고 해서 왔소만..",

        //13
        "아 화상검 말씀하시는겁니까?",

        //14
        "그렇게 부르오?",

        //15
        "도신에서 증기가 뿜어져나와 속도가 전과 달라 열까지 만들어내 그리 이름 붙였습니다. 근데 이를 어쩌나…",

        //16
        "무슨일있소?",

        //17
        "최근에 보안대에서 대량으로 무기를 주문해서 부품이 모자릅니다. 다음 부품이 들어오기까지 일주일 정도 걸립니다.",

        //18
        "(이를 어쩌지… 무기 없이 돌아다니는건 위험하다. 그렇다고 부품이 들어오는 걸 계속 기다릴 수는 없다.)"
        +"무슨 방법이 없겠소?",

        //19
        "태엽괴물의 부품이면 모르겠지만.. 그놈들은 너무 위험합니다. 아쉽지만 다음에 와주시지요.",

        //20
        "아니오. 내가 구해오지. 몇 개 정도면 되겠소?",

        //21
        "정말 그래주시겠습니까? 태엽과 기계부품을 각각 20개씩만 모아와주신다면 금방 만들어드리겠습니다."
        + "가는 길이 위험하니 일반 검과 일반 석궁을 드리겠습니다.",

        //22
        "알겠소.",

        //23
        "(기계부품이라… 지금은 쓰지 않는 선로에 가면 찾을 수 있겠지.)",




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

    int[] B_index = new int[14] {4,7,9,15,20,25,29,33,37,41,42,44,48,51}; //대화집을 끝낼 타이밍
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
                if (B_index[i] == index) //대화집을 끝낼 타이밍이라면
                    a = 1;
            if (a == 1)
            {
                //인덱스 설정
                gameObject.SetActive(false); //꺼버려 일단
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

            //여기다가 엔딩에 따라서 씬로드하자
            //gameObject.SetActive(false);
       
        }

    }
}
