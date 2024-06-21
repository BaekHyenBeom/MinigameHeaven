using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SwimSwimMiniGameManager : MiniGameManager
{
    private float gameTime = 0;
    public ObstaclePool obstaclePool { get; private set; }

    public void Awake()
    {
        // �ʱ� ����
        curScore = 0;
        gameType = MiniGameType.SwimSwim;

        obstaclePool = GetComponent<ObstaclePool>();

        InitMiniGame();
    }

    private void Start()
    {
        curScore = 0;
        Application.targetFrameRate = 30; // ȯ�漳���� ������ ������ ���� �ű�� �ű��
        InvokeRepeating("ObstacleCreate", 0.0f, 1.5f); // �ڷ�ƾ���ε� ������ ��
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        curScore = (int)gameTime; // ���� ��� ����, ���� ����
        curScoreNum.text = curScore.ToString();
    }

    void ObstacleCreate()
    {
        GameObject obj = obstaclePool.SpawnFromPool("Obstacle");
        SwimSwimObstacle obstacle = obj.GetComponent<SwimSwimObstacle>();
        obstacle.swimSwimMiniGameManager = GetComponent<SwimSwimMiniGameManager>();

        float size = Random.Range(0.4f, 1.4f);
        obj.transform.localScale = new Vector2(size * 2, size);
        float y = Random.Range(-4.0f, 5.0f);
        obj.transform.position = new Vector2(5f, y);
    }

    public override void HighScoreRecord()
    {
        throw new System.NotImplementedException();
    }
}
