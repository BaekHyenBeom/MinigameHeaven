using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StageManager : MiniGameManager
{
    public static StageManager Instance;
    public ObstaclePool obstaclePool { get; private set; }

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

        InitMiniGame();
        obstaclePool = GetComponent<ObstaclePool>();
     
    }
    private void Start()
    {

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
     
        float ranx = Random.Range(-2.2f, 2.2f);
        float rany = Random.Range(prey + 0.5f, prey + 2);
        
        obj.transform.position = new Vector2(ranx,rany);

       prex = ranx;
       prey = rany;

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
