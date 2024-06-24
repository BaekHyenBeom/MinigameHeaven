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
    int score = 0;
    int high = 0;


    public void NoWScore()
    {
        if (score  > (int)upController.transform.position.y)
        {
            return;

        }

        score =(int)upController.transform.position.y ;
        curScoreNumTxt.text = $"{score} ";

        if ((int)upController.transform.position.y <= score - 10f)
        {
            StageManager.Instance.GameOver();
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
       high = PlayerPrefs.GetInt("Best");
        topScoreNumTxt.text = $"{high} ";

    }
    private void FixedUpdate()
    {

        NoWScore();
        HighScore();
    }
    
}
