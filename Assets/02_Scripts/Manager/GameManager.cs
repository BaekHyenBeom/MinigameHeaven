using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public DataManager dataContaioner;
    public CharacterSO curCharacter;
    public MiniGameType curMinigame;
    public string curMinigameName;
    public MiniGameManager curMiniGameScript;

    public event Action MiniGameDescUI;
    public event Action CharacterDescUI;

    public void CallMinigameDescUI()
    {
        MiniGameDescUI?.Invoke();
    }

    public void CallCharacterDescUI()
    {
       CharacterDescUI?.Invoke();
    }
}
