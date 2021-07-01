using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public Popup popup;

    void Start()
    {
        popup.gameObject.SetActive(false);
    }
    public void Open()
    {
        popup.Init();
    }
    public void Close()
    {
        popup.Close();
    }
}
