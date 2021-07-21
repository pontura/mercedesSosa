using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearButton : MonoBehaviour
{
    public Sprite[] images_discos;
    public Sprite[] images_colaboracion;
    public Sprite[] images_premios;
    public Image[] images;


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
        switch(data.type)
        {
            case "discos":
                AddImages(images_discos);
                break;
            case "colaboraciones":
                AddImages(images_colaboracion);
                break;
            case "premios":
                AddImages(images_premios);
                break;
            default:
                images[0].enabled = false;
                images[1].enabled = false;
                break;
        }
    }
    void AddImages(Sprite[] arr)
    {
        images[0].enabled = true;
        images[1].enabled = true;
        images[0].sprite = arr[0];
        images[1].sprite = arr[1];
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
