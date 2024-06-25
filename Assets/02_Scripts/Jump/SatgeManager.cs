using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StageManager : MiniGameManager
{
    public static StageManager Instance;
    public ObstaclePool obstaclePool { get; private set; }

    [Header("StageManager Setting")]
    public float prex = -100;
    public float prey = -2.74f;

    private void Awake()
    {
      if (Instance == null)
        {
            Instance = this;
        }

        curScore = 0;
        gameType = MiniGameType.HighJump;

        obstaclePool = GetComponent<ObstaclePool>();
     
    }
    private void Start()
    {

        InitMiniGame();
        for (int i = 0; i < 20; i++)
        {
               createClouds();
        }
    }

   public void createClouds()
    {
        GameObject obj = obstaclePool.SpawnFromPool("Cloud");
       // CloudSpawnController cloudSpawnController = obj.GetComponent<CloudSpawnController>();
       // cloudSpawnController.satgeManager=GetComponent<SatgeManager>();
     
        float ranx = Random.Range(-2.5f, 3.5f);
        float rany = Random.Range(prey + 0.5f, prey + 2);
        
        obj.transform.position = new Vector2(ranx,rany);

       prex = ranx;
       prey = rany;

    }


   
    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
