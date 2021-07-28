using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearsManager : MonoBehaviour
{
    public YearButton yearButton;
    public YearButton finalButton;
    public Transform container;
    public float y_separationFactor;
    int firstYear;
    public int initialOffset = 100;
    public List<YearButton> all;
    public Filters filters;
    public Scrollbar scrollBar;
    public int yearID = 0;
    public float totalButtons_value = 0.54f;
    int totalYears;
    
    bool IsInOtherTypes(string[] arr, int filterID)
    {
        if (arr == null || arr.Length < 1) return false;
        foreach(string s in arr)
        {
            if (
               (filterID == 0 && s == "discos")
                ||
               (filterID == 1 && s == "premios")
                ||
               (filterID == 2 && s == "colaboraciones")
               )
                return true;
        }
        return false;
    }
    public void Init(int filterID)
    {
        totalYears = 0;
        yearID = 0;
        all.Clear();
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
                || (IsInOtherTypes(data.other_types, filterID))
               )
            {
                YearButton newButton;
                if (yearID >= Data.Instance.contentData.allData.data.Length-1)
                    newButton = Instantiate(finalButton, container);
                else
                    newButton = Instantiate(yearButton, container);

                newButton.transform.localScale = Vector3.one;
                newButton.Init(this, data, yearID);
                int _y = data.year - firstYear;
                //  newButton.transform.localPosition = new Vector2(0, -initialOffset - _y * y_separationFactor);
                newButton.transform.localPosition = new Vector2(0, -initialOffset - (yearID * y_separationFactor));
               
                all.Add(newButton);
                if(yearID == 0)
                    newButton.Clicked();
                yearID++;
                totalYears++;
            }
        }
        yearID = 0;
        scrollValue = 1;
        scrollBar.value = 1;
    }
    void MoveScroll()
    {

    }
    states state;
    enum states
    {
        IDLE,
        REPOSITION
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            state = states.IDLE;
        //if (Input.GetKeyDown(KeyCode.Z))
        //    Move(true);
        //else if (Input.GetKeyDown(KeyCode.X))
        //    Move(false);
        if(state == states.REPOSITION)
            scrollBar.value = Mathf.Lerp(scrollBar.value, scrollValue, scrollSmooth);
        if(Mathf.Abs(scrollBar.value- scrollValue)< minScrollSize)
        {
            state = states.IDLE;
            scrollBar.value = scrollValue;
        }
    }
    public float minScrollSize = 0.001f;
    public float scrollSmooth = 0.04f;

    float scrollValue;
    void UpdateScroll()
    {
        state = states.REPOSITION;
        if (totalYears > 0)
            scrollValue = 1 - ((float)yearID / (float)totalYears);
    }
    public void Move(bool isNext)
    {
        if (isNext)
            yearID++;
        else
            yearID--;
        if (yearID < 0)
        {
            yearID = 0;
            return;
        }
        if (yearID > all.Count - 1)
        {
            yearID = all.Count - 1;
            return;
        }
        all[yearID].Clicked();
    }
   
    public void OnClicked(YearButton yearButton)
    {
        foreach (YearButton b in all)
            if (b.isOn && b != yearButton)
                b.Reset();

        this.yearID = yearButton.yearID;

        if (yearButton.isOn)
            UIManager.Instance.Open(yearButton.data);
        else
            UIManager.Instance.Close();

        UpdateScroll();
    }
}
