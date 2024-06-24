using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameBtnUI : MonoBehaviour
{
    public MiniGameType gameType;
    public string miniGameName;

    public TextMeshProUGUI gameTxt;
    public Image gameIcon;
    public Sprite defaultIcon;
    public Animator animator;

    void OnEnable()
    {
        gameTxt.text = miniGameName;
        if (defaultIcon != null)
        {
            gameIcon.sprite = defaultIcon;
        }
    }

    public void SelectMiniGame()
    {
        SoundUtil.SfxSound("ButtonSound");
        GameManager.Instance.curMinigameName = miniGameName;
        GameManager.Instance.curMinigame = gameType;

        GameManager.Instance.ChangeBtnColor(GetComponent<Image>(), true, animator);
        GameManager.Instance.CallMinigameDescUI();
        //Debug.Log($"{miniGameName}가 선택되었습니다.");
    }
}
