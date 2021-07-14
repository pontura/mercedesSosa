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
    YearsManager manager;
    public ContentData.DataContent data;
    public void Init(YearsManager manager, ContentData.DataContent data)
    {
        this.manager = manager;
        this.data = data;
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

        manager.OnClicked(this);
    }
    public void Reset()
    {
        isOn = false;
        SetState();
    }
    void SetState()
    {
        on.SetActive(isOn);
        off.SetActive(!isOn);     
    }
}
