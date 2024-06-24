using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curScoreNum;
    [SerializeField] private TextMeshProUGUI highScoreNum;
    [SerializeField] private GameObject newRecordTxt;

    private void GameResult()
    {
        curScoreNum.text = GameManager.Instance.curMiniGameScript.curScore.ToString();
        if (DataManager.Instance.RenewalHighScore(GameManager.Instance.curMiniGameScript.curScore, GameManager.Instance.curMinigame))
        {
            newRecordTxt.SetActive(true);
        }
        highScoreNum.text = DataManager.Instance.GiveHighScore(GameManager.Instance.curMinigame).ToString();
    }
}
