using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public void Init()
    {
        gameObject.SetActive(true);
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
