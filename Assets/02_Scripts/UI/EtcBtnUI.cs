using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EtcBtnUI : MonoBehaviour
{
    public void GoHomeUI()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}
