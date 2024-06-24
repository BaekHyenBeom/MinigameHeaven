using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public DataManager dataContaioner;
    public CharacterSO curCharacter;
    public MiniGameType curMinigame;
    public string curMinigameName;
    public MiniGameManager curMiniGameScript;

    public event Action MiniGameDescUI;
    public event Action CharacterDescUI;

    // ���õ� �� ǥ�ÿ�
    private Color selectedColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    private Color defaultColor = new Color(175 / 255f, 175 / 255f, 175 / 255f, 1f);

    public Image curMiniGameBtn;
    public Image curCharacterBtn;
    public Animator curMiniGameAnim;
    public Animator curCharacterAnim;

    public void CallMinigameDescUI()
    {
        MiniGameDescUI?.Invoke();
    }

    public void CallCharacterDescUI()
    {
       CharacterDescUI?.Invoke();
    }

    public void ActiveMiniGame()
    {
        if (curMiniGameBtn != null) curMiniGameBtn.color = selectedColor;
        if (curMiniGameAnim != null) curMiniGameAnim.SetBool("isSelected", true);
    }

    public void ActiveCharacter()
    {
        if (curCharacterBtn != null) curCharacterBtn.color = selectedColor;
        if (curCharacterAnim != null) curCharacterAnim.SetBool("isSelected", true);
    }

    public void ChangeBtnColor(Image targetImage, bool isMiniGame, Animator animator)
    {
        if (isMiniGame)
        {
            if (curMiniGameBtn != null)
            {
                curMiniGameBtn.color = defaultColor;
            }
            if (curMiniGameAnim != null)
            {
                curMiniGameAnim.SetBool("isSelected", false);
            }
            if (targetImage == null) { curMiniGameBtn = null;}
            else { curMiniGameBtn = targetImage; }
            if (animator == null) { curMiniGameBtn = null; return; }
            else { curMiniGameAnim = animator; }
        }
        else
        {
            if (curCharacterBtn)
            {
                curCharacterBtn.color = defaultColor;
            }
            if (curCharacterAnim != null)
            {
                curCharacterAnim.SetBool("isSelected", false);
            }
            if (targetImage == null) { curCharacterBtn = null; }
            else { curCharacterBtn = targetImage; }
            if (animator == null) { curCharacterBtn = null; return; }
            else { curCharacterAnim = animator; }
        }
        targetImage.color = selectedColor;
        animator.SetBool("isSelected", true);
    }
}
