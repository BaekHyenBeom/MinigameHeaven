using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curScoreNumTxt;
    [SerializeField] private TextMeshProUGUI topScoreNumTxt;
    [SerializeField] UpController upController;
    [SerializeField] MiniGameManager curMiniGame;
    [SerializeField] StageManager curStageManager;
    int score = 0;
    int high = 0;

    public void NoWScore()
    {
        if (score < (int)curStageManager.curPlayerTransform.position.y)
        {
            score = (int)curStageManager.curPlayerTransform.position.y;
            curMiniGame.curScore = score;
            curScoreNumTxt.text = $"{score} ";
        }

        Vector3 view = Camera.main.WorldToScreenPoint(curStageManager.curPlayerTransform.position);
        if (view.y < -50)
        {
            StageManager.Instance.GameOver();
            return;
        }


    }
    
    public void HighScore()
    {
        if (high < score)
        {
            high = score;
            topScoreNumTxt.text = $"{high} ";
            
          PlayerPrefs.SetInt("Best", high);
           
        }
    }

    void Start()
    {
        if (curMiniGame.TryGetComponent<StageManager>(out StageManager stageManager))
        {
            curStageManager = stageManager;
        }
        //high = PlayerPrefs.GetInt("Best");
        // DataManager�� �����ϰڽ��ϴ�.
        high = DataManager.Instance.GiveHighScore(MiniGameType.HighJump);
        topScoreNumTxt.text = $"{high}";

    }
    private void FixedUpdate()
    {

        NoWScore();
        HighScore();
       
    }
}
