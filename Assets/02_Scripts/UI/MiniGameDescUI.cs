using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameDescUI : MonoBehaviour
{
    public TextMeshProUGUI MinigameNameTxt;
    public TextMeshProUGUI HighScoreNum;

    private void OnEnable()
    {
        Debug.Log("이벤트 연결");
        GameManager.Instance.MiniGameDescUI += DescSetting;
    }

    private void OnDisable()
    {
        Debug.Log("이벤트 해제");
        GameManager.Instance.MiniGameDescUI -= DescSetting;
    }

    private void DescSetting()
    {
        MinigameNameTxt.text = GameManager.Instance.curMinigameName;
        HighScoreNum.text = "반영 예정";
    }
}
