using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearsManager : MonoBehaviour
{
    public YearButton yearButton;
    public Transform container;
    public float y_separationFactor;
    int firstYear;
    public int initialOffset = 100;
    public List<YearButton> all;
    public Filters filters;
    public Scrollbar scrollBar;
    
    public void Init(int filterID)
    {        
        all.Clear();
        bool isFirst = false;
        Utils.RemoveAllChildsIn(container);
        firstYear = Data.Instance.contentData.allData.data[0].year;
        foreach (ContentData.DataContent data in Data.Instance.contentData.allData.data)
        {
            if (filterID == 3 || 
                (filterID == 0 && data.type == "discos")
                 ||
                (filterID == 1 && data.type == "premios")
                 ||
                (filterID == 2 && data.type == "colaboraciones")
                  ||
                (data.type == "bio")
               )
            {
                YearButton newButton = Instantiate(yearButton, container);
                newButton.transform.localScale = Vector3.one;
                newButton.Init(this, data);
                int _y = data.year - firstYear;
                newButton.transform.localPosition = new Vector2(0, -initialOffset - _y * y_separationFactor);
                all.Add(newButton);
                if(!isFirst)
                {
                    newButton.Clicked();
                    isFirst = true;
                }
            }
        }
        scrollBar.value = 1;
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
