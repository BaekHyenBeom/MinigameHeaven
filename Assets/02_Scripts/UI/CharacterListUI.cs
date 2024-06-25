using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListUI : MonoBehaviour
{
    [SerializeField] private List<CharacterBtnUI> Buttons;
    [SerializeField] private List<GameEnableCharacter> enableList;

    

    private void OnEnable()
    {
        GameManager.Instance.curCharacter = null; // 초기화 작업
        GameEnableCharacter curGame = enableList[(int)GameManager.Instance.curMinigame];
        for (int i = 0; i < curGame.enableCharacter.Count; i++)
        {
            Buttons[i].characterSO = curGame.enableCharacter[i];
        }

        for (int i = curGame.enableCharacter.Count; i < Buttons.Count; i++)
        {
            Buttons[i].characterSO = null;
        }
    }
}

[Serializable]
public class GameEnableCharacter
{
    public string name;
    public MiniGameType gameType;
    public List<CharacterSO> enableCharacter;
}