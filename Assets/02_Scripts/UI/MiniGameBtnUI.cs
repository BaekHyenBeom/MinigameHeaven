using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBtnUI : MonoBehaviour
{
    public MiniGameManager myMiniGameManager;

    public void SelectMiniGame()
    {
        GameManager.Instance.curMinigame = myMiniGameManager;
        Debug.Log($"{myMiniGameManager.gameType.ToString()}가 선택되었습니다.");
    }
}
