using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog_NameTag : MonoBehaviour
{
    private string[] Missionlines =
  {
        //0
        "�÷��̾�",
    
        //1
        "�÷��̾�",

        //2
        "�÷��̾�"

    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Missionlines[Dialogue.index];
    }
}
