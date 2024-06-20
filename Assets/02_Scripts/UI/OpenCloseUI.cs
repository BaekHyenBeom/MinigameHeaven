using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseUI : MonoBehaviour
{
    public GameObject targetUI;
    public void OpenUI()
    {
        targetUI.SetActive(true);
    }
    public void CloseUI()
    {
        targetUI.SetActive(false);
    }
}
