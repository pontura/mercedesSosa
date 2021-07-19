using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScreen : MonoBehaviour
{
    public GameObject panel;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        Events.OnPlayVideo += OnPlayVideo;
        Reset();
    }
    private void OnDestroy()
    {
        Events.OnPlayVideo -= OnPlayVideo;
    }
    void OnPlayVideo(string url)
    {
        panel.gameObject.SetActive(true);
        videoPlayer.url = url;
        videoPlayer.Play();
    }
    private void Reset()
    {
        panel.gameObject.SetActive(false);
    }
    public void Close()
    {
        Reset();
    }

}
