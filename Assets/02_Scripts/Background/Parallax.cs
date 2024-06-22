using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // ���� ���� ���� �� -> �Ϸ縦 720�ʷ� ġȯ -> �� Ÿ���� 180��(3��)
    private float day = 240f;
    private float currentTimer = 0f;
    private int curUnitOfTime = -1;

    public int CurUnitOfTime
    {
        get => curUnitOfTime;
        set
        {
            curUnitOfTime = value;
            ChangeUnitOfTime();
        }
    }

    private Transform[] unitOfBackgrounds;

    private Dictionary<int, SpriteRenderer[]> backgrounds = new Dictionary<int, SpriteRenderer[]>();


    public float speed = 0.01f;

    public bool isGameStart = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        unitOfBackgrounds = new Transform[transform.childCount];

        for (int i = 0; i < unitOfBackgrounds.Length; i++)
        {
            unitOfBackgrounds[i] = transform.GetChild(i);
            SpriteRenderer[] background = new SpriteRenderer[unitOfBackgrounds[i].childCount];
            for (int j = 0; j < unitOfBackgrounds[i].childCount; j++)
            {
                background[j] = unitOfBackgrounds[i].GetChild(j).GetComponent<SpriteRenderer>();
            }
            unitOfBackgrounds[i].gameObject.SetActive(false);
            backgrounds.Add(i, background);
        }
        CurUnitOfTime = 0;
    }

    private void Update()
    {
        if(isGameStart)
        {
            SetTime();
        }
    }


    private void LateUpdate()
    {
        if(isGameStart)
        {
            ActiveBackground();
        }
    }

    private void SetTime()
    {
        if (currentTimer - 0.05f >= day)
        {
            currentTimer = 0f;
        }

        currentTimer += Time.deltaTime;
    }
    private void ActiveBackground()
    {
        CurUnitOfTime = (int)(currentTimer / (day / 4));

        for (int i = 0; i < backgrounds[CurUnitOfTime].Length; i++)
        {
            Vector3 curPos = backgrounds[CurUnitOfTime][i].transform.position;
            Vector3 nextPos = Vector3.left * (speed * i * 0.1f) * Time.deltaTime;

            backgrounds[CurUnitOfTime][i].transform.position = curPos + nextPos;

            if (backgrounds[CurUnitOfTime][i].transform.position.x <= -backgrounds[CurUnitOfTime][i].bounds.size.x)
            {
                backgrounds[CurUnitOfTime][i].transform.position = Vector3.zero;
            }
        }
        // ���� �б�� ���� �бⰡ 2�̻� ���̳��� �۵�. ���� ����� Ű�� ���̸� ����


        //for (int i = 0; i < backgrounds.Count; i++)
        //{
        //    Vector3 curPos = backgrounds[i].transform.position;
        //    Vector3 nextPos = Vector3.left * (speed * i * 0.1f) * Time.deltaTime;

        //    backgrounds[i].transform.position = curPos + nextPos;

        //    if (backgrounds[i].transform.position.x <= -backgrounds[i].bounds.size.x)
        //    {
        //        backgrounds[i].transform.position = Vector3.zero;
        //    }
        //}
    }
    private void ChangeUnitOfTime()
    {
        for(int i = 0; i < unitOfBackgrounds.Length; i++)
        {
            unitOfBackgrounds[i].gameObject.SetActive(i == CurUnitOfTime);
        }
    }
}
