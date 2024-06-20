using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public DataManager dataContaioner;
    public CharacterSO curCharacter;
    public MiniGameType curMinigame;
}
