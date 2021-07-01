using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearButton : MonoBehaviour
{
    public Text[] fields;
    public GameObject on;
    public GameObject off;
    public bool isOn;
    Animation anim;


    public void Init(ContentData.DataContent data)
    {
        SetState();
        foreach (Text field in fields)
            field.text = data.year.ToString();
    }
    public void Clicked()
    {
        isOn = !isOn;
        SetState();
        if (isOn)
            GetComponent<Animation>().Play("btn_on");
        else
            GetComponent<Animation>().Play("btn_off");

        if (isOn)
            UIManager.Instance.Open();
        else
            UIManager.Instance.Close();
    }
    void SetState()
    {
        on.SetActive(isOn);
        off.SetActive(!isOn);
     
    }
}
