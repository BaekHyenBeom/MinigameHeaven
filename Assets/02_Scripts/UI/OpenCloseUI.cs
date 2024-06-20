using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseUI : MonoBehaviour
{
    public GameObject targetUI;
    public List<GameObject> ignoreUI;

    public void OpenUI()
    {
        targetUI.SetActive(true);
    }
    public void CloseUI()
    {
        targetUI.SetActive(false);
    }
    public void OpenAndCloseUI()
    {
        targetUI.SetActive(true);
        foreach(GameObject obj in ignoreUI)
        {
            obj.SetActive(false);
        }
    }
}
