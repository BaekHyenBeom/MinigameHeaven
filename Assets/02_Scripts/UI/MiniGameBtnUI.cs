using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBtnUI : MonoBehaviour
{
    public MiniGameType gameType;

    public void SelectMiniGame()
    {
        GameManager.Instance.curMinigame = gameType;
        Debug.Log($"{gameType}�� ���õǾ����ϴ�.");
    }
}
