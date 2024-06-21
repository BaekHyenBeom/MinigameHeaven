using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingRecordUI : MonoBehaviour
{
    [SerializeField] private MiniGameType curType;
    [SerializeField] private string minigameName;

    [Header("UI Settings")]
    public TextMeshProUGUI minigameNameTxt;
    public TextMeshProUGUI minigameHighScoreNum;

    private void OnEnable()
    {
        minigameNameTxt.text = minigameName;
        if (curType == MiniGameType.None)
        {
            minigameHighScoreNum.text = "None";
            return;
        }
        minigameHighScoreNum.text =  DataManager.Instance.GiveHighScore(curType).ToString();
    }
}