using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeJumpMiniGameManager : MiniGameManager
{
    public RopeCollider ropeCollider;

    public void Awake()
    {
        // �ʱ� ����
        curScore = 0;
        gameType = MiniGameType.RopeJump;

        InitMiniGame();
    }

    public void Start()
    {
        Application.targetFrameRate = 30; // ȯ�漳���� ������ ������ ���� �ű�� �ű��

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
