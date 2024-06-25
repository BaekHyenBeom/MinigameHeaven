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
    int score = 0;
    int high = 0;


    public void NoWScore()
    {
        if (score < (int)upController.transform.position.y)
        {
            score = (int)upController.transform.position.y;
            curMiniGame.curScore = score;
            curScoreNumTxt.text = $"{score} ";
        }

        Vector3 view = Camera.main.WorldToScreenPoint(upController.transform.position);
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
        //high = PlayerPrefs.GetInt("Best");
        // DataManager로 수정하겠습니다.
        high = DataManager.Instance.GiveHighScore(MiniGameType.HighJump);
        topScoreNumTxt.text = $"{high}";

    }
    private void FixedUpdate()
    {

        NoWScore();
        HighScore();
       
    }
    
}
