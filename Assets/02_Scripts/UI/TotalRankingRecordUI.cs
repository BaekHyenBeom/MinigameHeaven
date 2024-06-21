using TMPro;
using UnityEngine;

public class TotalRankingRecordUI : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI minigameHighScoreNum;

    private void OnEnable()
    {
        minigameHighScoreNum.text = DataManager.Instance.GiveTotalScore().ToString();
    }
}