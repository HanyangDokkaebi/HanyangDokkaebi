using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    [SerializeField]
    private Slider HPbar;
    [SerializeField]
    private Slider ManaBar;
    // Start is called before the first frame update

    public static float MaxHp = 100;
    public static float MaxMana = 100;
    public static float HP = 0;
    public static float Mana = 0;

    void Start()
    {
        HPbar.value = (float)HP / (float)MaxHp;
        ManaBar.value = (float)Mana / (float)MaxMana;
    }

    // Update is called once per frame
    void Update()
    { 
        HandleHp();
    }
    private void HandleHp()
    {
        HPbar.value = Mathf.Lerp(HPbar.value, (float)HP / (float)MaxHp, Time.deltaTime * 10);
        ManaBar.value = Mathf.Lerp(ManaBar.value, (float)Mana / (float)MaxMana, Time.deltaTime * 10);
    }
}