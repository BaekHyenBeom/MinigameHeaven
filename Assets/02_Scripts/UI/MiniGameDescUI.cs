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
        Debug.Log("�̺�Ʈ ����");
        GameManager.Instance.MiniGameDescUI += DescSetting;
    }

    private void OnDisable()
    {
        Debug.Log("�̺�Ʈ ����");
        GameManager.Instance.MiniGameDescUI -= DescSetting;
    }

    private void DescSetting()
    {
        if (GameManager.Instance.curMinigameName != null)
        {
            MinigameNameTxt.text = GameManager.Instance.curMinigameName;
        }
        else
        {
            MinigameNameTxt.text = "������\n�����ϼ���";
        }
        
        HighScoreNum.text = "�ݿ� ����";
    }
}
