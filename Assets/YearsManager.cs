using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearsManager : MonoBehaviour
{
    public YearButton yearButton;
    public Transform container;
    public float y_separationFactor;
    int firstYear;
    public int initialOffset = 100;
    public List<YearButton> all;

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
       // Utils.RemoveAllChildsIn(container);
        firstYear = Data.Instance.contentData.allData.data[0].year;
        foreach (ContentData.DataContent data in Data.Instance.contentData.allData.data)
        {
            YearButton newButton = Instantiate(yearButton, container);
            newButton.transform.localScale = Vector3.one;
            newButton.Init(this, data);
            int _y = data.year - firstYear;
            newButton.transform.localPosition = new Vector2(0, -initialOffset - _y*y_separationFactor);
            print(newButton.transform.localPosition);
            all.Add(newButton);
        }
    }
    public void OnClicked(YearButton yearButton)
    {
        foreach (YearButton b in all)
            if (b.isOn && b != yearButton)
                b.Reset();

        if (yearButton.isOn)
            UIManager.Instance.Open(yearButton.data);
        else
            UIManager.Instance.Close();
    }
}
