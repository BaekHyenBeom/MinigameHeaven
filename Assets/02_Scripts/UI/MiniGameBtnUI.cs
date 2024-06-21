using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameBtnUI : MonoBehaviour
{
    public MiniGameType gameType;
    public string miniGameName;

    public TextMeshProUGUI gameTxt;

    void OnEnable()
    {
        gameTxt.text = miniGameName;
    }

    public void SelectMiniGame()
    {
        SoundUtil.SfxSound("ButtonSound");
        GameManager.Instance.curMinigameName = miniGameName;
        GameManager.Instance.curMinigame = gameType;

        GameManager.Instance.CallMinigameDescUI();
        //Debug.Log($"{miniGameName}가 선택되었습니다.");
    }
}
