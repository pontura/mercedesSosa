using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager mInstance = null;
    public Animator menuAnim;
    public int sec;
    public int idleTime = 5;
    bool isIdle;
    public Animator anim;


    public static UIManager Instance
    {
        get { return mInstance; }
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        mInstance = this;
        Loop();
        Splash();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ResetTimer();
    }
    void Loop()
    {
        if(!isIdle && !GetComponent<VideoScreen>().videoPlayer.isPlaying)
            sec++;
        Invoke("Loop", 1);
        if(sec > idleTime)
        {
            ResetTimer();
            Splash();
        }
    }
    void ResetTimer()
    {
        sec = 0;
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
        GetComponent<VideoScreen>().Close();
        isIdle = true;
        anim.Play("ui_splash_entry");
    }
    public void SplashOff()
    {
        isIdle = false;
        anim.Play("ui_timeline_entry");
    }
    bool isOpen;
    public void ToggleMenu()
    {
        isOpen = !isOpen;
        if(isOpen)
            menuAnim.Play("menu_on_entry");
        else
            menuAnim.Play("menu_off_entry");
    }
}
