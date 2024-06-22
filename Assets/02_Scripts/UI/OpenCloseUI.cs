using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseUI : MonoBehaviour
{
    public GameObject targetUI;
    public List<GameObject> ignoreUI;
    
    public void OpenUI()
    {
        SoundUtil.SfxSound("ButtonSound");
        targetUI.SetActive(true);
    }
    public void CloseUI()
    {
        SoundUtil.SfxSound("ButtonSound");
        targetUI.SetActive(false);
    }
    public void OpenAndCloseUI()
    {
        SoundUtil.SfxSound("ButtonSound");
        targetUI.SetActive(true);
        foreach(GameObject obj in ignoreUI)
        {
            obj.SetActive(false);
        }
    }
}
