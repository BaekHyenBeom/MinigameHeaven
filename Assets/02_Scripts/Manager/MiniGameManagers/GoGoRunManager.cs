using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GoGoRunManager : MiniGameManager
{
    #region Public Field

    public TMP_Text txtCount = null;

    public GoGoRunCharacter character;

    #endregion

    #region Private Field

    private bool isStart = false;

    private int countDown = 3;

    private float score = 0f;

    private const string countDownStart = "CountDownStart";
    private const string counting = "Counting";

    #endregion

    #region Life Cycle

    private IEnumerator Start()
    {
        InitMiniGame();
        SetScore();

        txtCount.gameObject.SetActive(true);
        while(countDown > 0)
        {
            txtCount.text = countDown.ToString();
            SoundManager.Instance.PlaySfxSound(counting);

            yield return CoroutineHelper.WaitForSeconds(1f);

            countDown--;
        }

        SoundManager.Instance.PlaySfxSound(countDownStart);
        txtCount.text = "시작!!!!";
        yield return CoroutineHelper.WaitForSeconds(1.5f);
        SoundManager.Instance.PlayBgm("GoGoRun");

        CallStart();
        txtCount.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (isStart)
        {
            score += Time.deltaTime;
            SetScore();
            HighScoreRecord();
        }
    }

    #endregion
    public override void CallPause()
    {
        // Invoke 기능 전
        isStart = false;
        base.CallPause();
        // Invoke 기능 후
    }

    public override void CallStart()
    {
        // Invoke 기능 전
        isStart = true;
        base.CallStart();
        // Invoke 기능 후

    }

    public override void GameOver()
    {
        base.GameOver();

        SoundManager.Instance.StopBgm();
        SoundManager.Instance.PlaySfxSound("Fail");
    }

    public override void HighScoreRecord()
    {
        if(int.TryParse(topScoreNum.text, out int result))
        {
            if (curScore > result)
            {
                topScoreNum.text = $"{curScore}";
            }
        }
    }



    public void SetScore()
    {
        base.SetScore();
        curScore = ((int)score);
        curScoreNum.text = curScore.ToString();
    }

    public override void InitMiniGame()
    {
        base.InitMiniGame();

        GameObject go = Instantiate(GameManager.Instance.curCharacter.playerPrefab, spawnTransform.position, Quaternion.identity, spawnTransform);
        go.name = GameManager.Instance.curCharacter.characterName;

        go.TryGetComponent(out character);

        score = 0;
    }
}
