using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeJumpMiniGameManager : MiniGameManager
{
    public RopeCollider ropeCollider;

    public void Awake()
    {
        // 초기 세팅
        curScore = 0;
        gameType = MiniGameType.RopeJump;

        InitMiniGame();
    }

    public void Start()
    {
        Application.targetFrameRate = 30; // 환경설정에 프레임 조절이 들어가면 거기로 옮기기

        RopeCollider rope = ropeCollider.GetComponent<RopeCollider>();
        rope.ropeJumpMiniGameManager = GetComponent<RopeJumpMiniGameManager>();
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
