using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public int _width = 530;
    public Text title;
    public Text popupText;
    public Image popupImage;
    public PopupVideoAsset popupVideo;
    public Transform container;
    ContentData.DataContent data;

    public void Init(ContentData.DataContent data)
    {
        this.data = data;
        Utils.RemoveAllChildsIn(container);

        if (data.year == 0)
            title.text = "Mercedes eterna";
        else
            title.text = data.year.ToString();

        gameObject.SetActive(true);
        GetComponent<Animation>().Play("info_entry");
        Invoke("Delayed", 0.7f);
    }
    void Delayed()
    {
        foreach (ContentData.YearData yearData in data.content)
        {
            if (yearData.text != null)
                AddText(yearData);
            else if (yearData.imageURL != null)
                AddImage(yearData, data.year.ToString());
            else if (yearData.videoURL != null)
                AddVideo(yearData, data.year.ToString());
        }
    }
    void AddText(ContentData.YearData yearData)
    {
        Text asset = Instantiate(popupText, container);
        asset.text = yearData.text;
    }
    void AddImage(ContentData.YearData yearData, string year)
    {
        string folderPath = Application.streamingAssetsPath + "/material/" + year + "/";
        string url = Path.Combine(folderPath, yearData.imageURL);
        Image asset = Instantiate(popupImage, container);
        StartCoroutine(AddImageRoutine(asset, url));
    }
    void AddVideo(ContentData.YearData yearData, string year)
    {
        string folderPath = Application.streamingAssetsPath + "/material/" + year + "/";
        string url = Path.Combine(folderPath, yearData.videoURL);
        PopupVideoAsset asset = Instantiate(popupVideo, container);
        asset.Init(this, yearData);
        StartCoroutine(AddImageRoutine(asset.image, url+ ".png"));
    }
    IEnumerator AddImageRoutine(Image asset, string url)
    {  
        Debug.Log("Load image: " + url);
        byte[] imgData;

        if (url.Contains("://") || url.Contains(":///"))
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            imgData = www.downloadHandler.data;
        }
        else
        {
            imgData = File.ReadAllBytes(url);
        }
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imgData);

        Vector2 pivot = new Vector2(0.5f, 0.5f);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), pivot, 100.0f);
        asset.sprite = sprite;
          
       
        float h =  asset.preferredHeight * _width / asset.preferredWidth;
        //print(h + "    " + asset.preferredWidth + " " + asset.preferredHeight);

        asset.GetComponent<RectTransform>().sizeDelta = new Vector2(_width, h);

    }
   
    public void Close()
    {
        CancelInvoke();
        GetComponent<Animation>().Play("info_exit");
        Invoke("Reset", 0.6f);
    }
    private void Reset()
    {
        gameObject.SetActive(false);
    }
    public void OpenVideo(ContentData.YearData yearData)
    {
        Events.OnPlayVideo(Application.streamingAssetsPath +  "/material/" + data.year + "/"  + yearData.videoURL + ".mp4");
    }
}
