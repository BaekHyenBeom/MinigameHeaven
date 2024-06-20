using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMiniGameManager : MiniGameManager
{
    public void Awake()
    {
        // 초기 세팅
        curScore = 0;
        gameType = MiniGameType.Test;
        InitMiniGame();
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
