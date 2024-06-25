using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveFileInitUI : MonoBehaviour
{
    public void InitRanking()
    {
        DataManager.Instance.InitRanking();
        SceneManager.LoadScene("MainScene");
    }
}
