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
    public GameObject[]  cloudPrefab; // ���� ������
    public int numberOfClouds = 10; // ������ ���� ����
     float x;  // ������ ������ ���� ����
    public float y; // ������ ������ ���� ����
     Vector2 offset=new Vector2(0.5f,1.5f);

    void Start()
    {
        makeClouds();
    }
                                   
    void makeClouds()
    {
        // numberOfClouds ��ŭ �ݺ��ؼ� ���� ����
        for (int i = 0; i < numberOfClouds; i++)
        {
            // ������ ��ġ ���
            float x = Random.Range(-2.4f, 2.4f);
            float y= Random.Range(-5.5f, 5f);
           
            transform.position = new Vector2(x, y);

            //������ y������  1.5  x ������  0.5 ���� 

            // ���� ����
            Instantiate(cloudPrefab[Random.Range(0, 5)], new Vector3(transform.position.x + (i * offset.x), transform.position.y + (i * offset.y), (1f * i) + 0.01f * i), Quaternion.identity, transform);
        }
    }
}

    //    public GameObject[] Clouds; // Ŭ���� ������ �迭
    //    public int numberOfClouds = 5; // ������ ������ ����
    //    [SerializeField] Vector2 offset; //���� ����
    //    void Start()
    //    {
    //        SpawnClouds();
    //    }

    //    void SpawnClouds()
    //    {
    //        for (int i = 0; i < numberOfClouds; i++)
    //        {
    //            // ȭ���� ���� �Ʒ����� ���� ��ܱ����� ������ ����
    //            Vector3 screenBounds = new Vector3(-2, -5, 0);

    //            // ������ ȭ�� ��ġ ����
    //            Vector3 randomPosition = new Vector3(screenBounds.x + (i * offset.x), screenBounds.y + (i * offset.y), (5f * i) + 0.01f * i);

    //            // Ŭ���� ������ �� �����ϰ� �����Ͽ� ����
    //            GameObject randomCloud = Clouds[Random.Range(0, Clouds.Length)];
    //            Instantiate(randomCloud, randomPosition, Quaternion.identity);
    //        }
    //    }

    //}


    //[SerializeField] GameObject Cloud; //���� ���� 
    //[SerializeField] Transform CloudParent; // ���� ����  ��ġ 
    //                                        //List<GameObject>[] pools;
    //[SerializeField] int x;
    //[SerializeField] int y;

    //// [SerializeField] Vector2 pos;   //���� ���� ��ġ 
    //[SerializeField] GameObject[] Clouds;

    //Vector2 Clousd1;  //���͸� �̿��ؼ� 




    //void Start()
    //{


    //    CloudParent = this.transform;   //���� ��ġ 
    //    Clousd1 = new Vector2(0, 5);  //���� ������ 6��
    //    MakeClouds(Clousd1);
    //}

    //public void MakeClouds(Vector2 Cloud)
    //{
    //    for (int i = 0; i < 30; i++)
    //    {
    //        Instantiate(Clouds[Random.Range(0, 5)], transform.position, Quaternion.identity);

    //    }
    //}
    

