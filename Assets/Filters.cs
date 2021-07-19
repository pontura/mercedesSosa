using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filters : MonoBehaviour
{
    public FilterButton[] all;
    public int activeFilter = 3;
    public YearsManager yearsManager;

    private void Start()
    {
        foreach (FilterButton fb in all)
        {
            fb.Init(this);
        }
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
        all[all.Length - 1].Clicked();
    }
    public void OnClicked(FilterButton button)
    {
        foreach (FilterButton b in all)
            if (b.isOn && b != button)
                b.Reset();
        this.activeFilter = button.id;
        yearsManager.Init(activeFilter);
    }
}
