using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public Popup popup;
    bool isOpen;
    ContentData.DataContent data;

    void Start()
    {
        popup.gameObject.SetActive(false);
    }
    public void Open(ContentData.DataContent data)
    {
        this.data = data;
        StopAllCoroutines();
        if (isOpen)
        {
            StartCoroutine( ReOpen() );
        }
        else
        {
            popup.Init(data);
            isOpen = true;
        }
    }
    IEnumerator ReOpen()
    {
        DoClose();
        yield return new WaitForSeconds(0.7f);
        isOpen = false;
        Open(data);
    }
    public void Close()
    {
        StopAllCoroutines();
        DoClose();
        isOpen = false;
    }
    public void DoClose()
    {       
        popup.Close();
    }
}
