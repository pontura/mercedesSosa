using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupVideoAsset : MonoBehaviour
{
    public Image image;
    Popup manager;
    ContentData.YearData yearData;

    public void Init(Popup manager, ContentData.YearData yearData)
    {
        this.manager = manager;
        this.yearData = yearData;
    }
    public void OnClicked()
    {
        manager.OpenVideo(yearData);
    }
}
