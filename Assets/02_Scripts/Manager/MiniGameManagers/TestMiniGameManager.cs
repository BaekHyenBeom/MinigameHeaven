using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMiniGameManager : MiniGameManager
{
    public void Awake()
    {
        // �ʱ� ����
        curScore = 0;
        gameType = MiniGameType.Test;
        InitMiniGame();
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
