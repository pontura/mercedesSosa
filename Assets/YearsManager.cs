using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearsManager : MonoBehaviour
{
    public YearButton yearButton;
    public Transform container;
    public float y_separationFactor;
    int firstYear;
    int offset = 100;
    void Start()
    {
        Loop();
    }
    void Loop()
    {
        if (Data.Instance.contentData.allData.data.Length > 0)
            AllLoaded();
        else
           Invoke("Loop", 0.1f);
    }
    void AllLoaded()
    {
        firstYear = Data.Instance.contentData.allData.data[0].year;
        foreach (ContentData.DataContent data in Data.Instance.contentData.allData.data)
        {
            YearButton newButton = Instantiate(yearButton, container);
            newButton.transform.localScale = Vector3.one;
            newButton.Init(data);
            int _y = data.year - firstYear;
            newButton.transform.localPosition = new Vector2(0, -offset - _y*y_separationFactor);
            print(newButton.transform.localPosition);
        }
    }
}
