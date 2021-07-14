using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager mInstance = null;

    public static UIManager Instance
    {
        get { return mInstance; }
    }
    private void Awake()
    {
        mInstance = this;
    }
    public PopupManager popupManager;

    public void Open(ContentData.DataContent data)
    {
        popupManager.Open(data);
    }
    public void Close()
    {
        popupManager.Close();
    }
}
