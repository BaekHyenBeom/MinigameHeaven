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
        score = (int)upController.transform.position.y;
        curScoreNumTxt.text = $"{score} ";

    }
    public void HighScore()
    {
        if (high < score)
        {
            high = score;
            topScoreNumTxt.text = $"{high} ";
            //    newHight.text = $"{score} M";
            PlayerPrefs.SetInt("Best", high);
           
        }
    }



    void Start()
    {
        high = PlayerPrefs.GetInt("Best");
        topScoreNumTxt.text = $"{high} ";

    }

    // Update is called once per frame
    void Update()
    {
        NoWScore();
        HighScore();
    }
}
