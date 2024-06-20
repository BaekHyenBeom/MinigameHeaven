using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject targetUI;
    public void OpenUI()
    {
        Time.timeScale = 0f;
        targetUI.SetActive(true);
    }
    public void CloseUI()
    {
        Time.timeScale = 1.0f;
        targetUI.SetActive(false);
    }
}
