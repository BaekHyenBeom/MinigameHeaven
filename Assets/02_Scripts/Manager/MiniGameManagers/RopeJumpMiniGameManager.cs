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
        SetScore();
        InitPlayer();
    }



    private void Update()
    {
        curScoreNum.text = curScore.ToString();
        if (curScore > DataManager.Instance.GiveHighScore(MiniGameType.RopeJump))
        {
            topScoreNum.text = curScore.ToString();
        }
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
