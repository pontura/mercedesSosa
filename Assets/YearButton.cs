using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearButton : MonoBehaviour
{
    public Text field;

    public void Init(ContentData.DataContent data)
    {
        field.text = data.year.ToString();
    }
    public void Clicked()
    {

    }
}
