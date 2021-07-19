using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterButton : MonoBehaviour
{
    public Text[] fields;
    public GameObject on;
    public GameObject off;
    public bool isOn;
    //Animation anim;
    Filters manager;
    public int id;

    public void Init(Filters manager)
    {
        this.manager = manager;
        SetState();
    }
    public void Clicked()
    {
        isOn = !isOn;
        SetState();
        //if (isOn)
        //    GetComponent<Animation>().Play("btn_on");
        //else
        //    GetComponent<Animation>().Play("btn_off");

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

