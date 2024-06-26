using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SwimSwimMiniGameManager : MiniGameManager
{
    private float gameTime = 0;
    public ObstaclePool obstaclePool { get; private set; }
    public SwimSwimAir swimSwimAir;

    public void Awake()
    {
        // 초기 세팅
        curScore = 0;
        gameType = MiniGameType.SwimSwim;

        obstaclePool = GetComponent<ObstaclePool>();

        InitMiniGame();
        SetScore();
        InitPlayer();
    }

    private void Start()
    {
        curScore = 0;
        Application.targetFrameRate = 30; // 환경설정에 프레임 조절이 들어가면 거기로 옮기기
        InvokeRepeating("ObstacleCreate", 0.0f, 1.5f); // 코루틴으로도 가능할 듯

        SwimSwimAir air = swimSwimAir.GetComponent<SwimSwimAir>();
        air.swimSwimMiniGameManager = GetComponent<SwimSwimMiniGameManager>();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        curScore = (int)gameTime; // 점수 계산 공식, 변경 가능
        curScoreNum.text = curScore.ToString();
    }

    void ObstacleCreate()
    {
        int fishTypeNum = Random.Range(0, 3);
        string fishType;

        switch (fishTypeNum)
        {
            case 0: fishType = "FishBig"; break;
            case 1: fishType = "FishDart"; break;
            case 2: fishType = "FishMid"; break;
            default: fishType = "FishBig"; break;
        }

        FishCreate(fishType);
    }

    void FishCreate(string fishType)
    {
        GameObject obj = obstaclePool.SpawnFromPool(fishType);

        SwimSwimObstacle obstacle = obj.GetComponent<SwimSwimObstacle>();
        obstacle.swimSwimMiniGameManager = GetComponent<SwimSwimMiniGameManager>();

        float size = Random.Range(4.0f, 6.0f);
        obj.transform.localScale = new Vector2(size, size);
        float y = Random.Range(-2.5f, 5.0f);
        obj.transform.position = new Vector2(5f, y);
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
