using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoGoRunManager : MiniGameManager
{
    public event Action onGameStart;

    public TMP_Text txtTimer;

    private int countDown = 3;
    IEnumerator Start()
    {
        while (countDown > 0)
        {
            txtTimer.text = $"{countDown}";
            yield return CoroutineHelper.WaitForSeconds(1);
            countDown--;
        }
        GameStart();
        yield break;

    }
    public void GameStart()
    {
        onGameStart?.Invoke();
    }
    public override void HighScoreRecord()
    {
        
    }

    public override void InitMiniGame()
    {
        base.InitMiniGame();
    }
    public override void GameOver()
    {
        base.GameOver();
    }
}
