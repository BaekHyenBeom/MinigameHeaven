using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class CloudSpawnController : MonoBehaviour
{
    public GameObject[]  cloudPrefab; // 구름 프리팹
    public int numberOfClouds = 10; // 생성할 구름 개수
     float x;  // 구름이 생성될 가로 범위
    public float y; // 구름이 생성될 세로 범위
     Vector2 offset=new Vector2(0.5f,1.5f);

    void Start()
    {
        makeClouds();
    }
                                   
    void makeClouds()
    {
        // numberOfClouds 만큼 반복해서 구름 생성
        for (int i = 0; i < numberOfClouds; i++)
        {
            // 랜덤한 위치 계산
            float x = Random.Range(-2.4f, 2.4f);
            float y= Random.Range(-5.5f, 5f);
           
            transform.position = new Vector2(x, y);

            //구름은 y간격이  1.5  x 간격은  0.5 정도 

            // 구름 생성
            Instantiate(cloudPrefab[Random.Range(0, 5)], new Vector3(transform.position.x + (i * offset.x), transform.position.y + (i * offset.y), (1f * i) + 0.01f * i), Quaternion.identity, transform);
        }
    }
}

    //    public GameObject[] Clouds; // 클라우드 프리팹 배열
    //    public int numberOfClouds = 5; // 생성할 구름의 개수
    //    [SerializeField] Vector2 offset; //벽돌 간격
    //    void Start()
    //    {
    //        SpawnClouds();
    //    }

    //    void SpawnClouds()
    //    {
    //        for (int i = 0; i < numberOfClouds; i++)
    //        {
    //            // 화면의 좌측 아래에서 우측 상단까지의 범위를 설정
    //            Vector3 screenBounds = new Vector3(-2, -5, 0);

    //            // 랜덤한 화면 위치 생성
    //            Vector3 randomPosition = new Vector3(screenBounds.x + (i * offset.x), screenBounds.y + (i * offset.y), (5f * i) + 0.01f * i);

    //            // 클라우드 프리팹 중 랜덤하게 선택하여 생성
    //            GameObject randomCloud = Clouds[Random.Range(0, Clouds.Length)];
    //            Instantiate(randomCloud, randomPosition, Quaternion.identity);
    //        }
    //    }

    //}


    //[SerializeField] GameObject Cloud; //구름 생성 
    //[SerializeField] Transform CloudParent; // 구름 생성  위치 
    //                                        //List<GameObject>[] pools;
    //[SerializeField] int x;
    //[SerializeField] int y;

    //// [SerializeField] Vector2 pos;   //구름 생성 위치 
    //[SerializeField] GameObject[] Clouds;

    //Vector2 Clousd1;  //벡터를 이용해서 




    //void Start()
    //{


    //    CloudParent = this.transform;   //시작 위치 
    //    Clousd1 = new Vector2(0, 5);  //구름 프리팹 6개
    //    MakeClouds(Clousd1);
    //}

    //public void MakeClouds(Vector2 Cloud)
    //{
    //    for (int i = 0; i < 30; i++)
    //    {
    //        Instantiate(Clouds[Random.Range(0, 5)], transform.position, Quaternion.identity);

    //    }
    //}
    

