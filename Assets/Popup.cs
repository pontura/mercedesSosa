using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Text title;

    public void Init(ContentData.DataContent data)
    {
        title.text = data.year.ToString();
        gameObject.SetActive(true);
        GetComponent<Animation>().Play("info_entry");
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
}
