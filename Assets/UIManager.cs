using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager mInstance = null;
    Animator anim;

    public static UIManager Instance
    {
        get { return mInstance; }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
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
    public void Splash()
    {
        anim.Play("ui_splash_entry");
    }
    public void SplashOff()
    {
        anim.Play("ui_timeline_entry");
    }
}
