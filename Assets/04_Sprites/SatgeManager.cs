using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SatgeManager : MiniGameManager
{

    public ObstaclePool obstaclePool { get; private set; }

    float prex = -100;
    float prey = -2.74f;


    private void Awake()
    {
      
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

        

        
     // Instantiate(obj, new Vector2(ranx, rany), Quaternion.identity);
       


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
