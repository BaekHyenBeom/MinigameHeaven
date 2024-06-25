using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MiniGameType
{
    None = -2,
    Test = -1,
    RopeJump = 0,
    HighJump,
    GoGoRun,
    SwimSwim,
}

public abstract class MiniGameManager : MonoBehaviour
{
    public int curScore;
    public MiniGameType gameType;

    [Header("PlayerSettings")]
    public Transform spawnTransform;

    [Header("UI Settings")]
    public GameObject GameOverPanel;
    public TextMeshProUGUI curScoreNum;
    public TextMeshProUGUI topScoreNum;

    public event Action OnStart;
    public event Action OnPause;

    public virtual void InitMiniGame()
    {
       // Instantiate(GameManager.Instance.curCharacter.playerPrefab, spawnTransform.position, Quaternion.identity);
        GameManager.Instance.curMiniGameScript = this;
        if (TryGetComponent<Character>(out Character character))
        {
            character.curMiniGame = this;
            character.curCharacter = GameManager.Instance.curCharacter;
        }

        // Test��
        //Invoke("GameOver", 5f);
    }

    public virtual void GameOver()
    {
        Time.timeScale = 0.0f;
        GameOverPanel.SetActive(true);
    }

    public virtual void CallStart()
    {
        OnStart?.Invoke();
    }

    public virtual void CallPause()
    {
        OnPause?.Invoke();

    }

    public abstract void HighScoreRecord();
}
