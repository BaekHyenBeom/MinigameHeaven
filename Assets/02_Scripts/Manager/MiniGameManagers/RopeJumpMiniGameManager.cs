using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeJumpMiniGameManager : MiniGameManager
{

    private void Awake()
    {
        // �ʱ� ����
        curScore = 0;
        gameType = MiniGameType.RopeJump;

        InitMiniGame();
    }



    private void Update()
    {
        curScoreNum.text = curScore.ToString();
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
