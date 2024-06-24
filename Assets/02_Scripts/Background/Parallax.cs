using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GoGoRunManager goGoRunManager;
    // 오전 오후 저녁 밤 -> 하루를 720초로 치환 -> 각 타임은 180초(3분)
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

    [SerializeField]
    private Transform floor;

    private Dictionary<int, SpriteRenderer[]> backgrounds = new Dictionary<int, SpriteRenderer[]>();


    public float speed = 0.01f;

    public bool isGameStart = false;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        goGoRunManager.onGameStart += () => isGameStart = true;
    }

    private void OnDisable()
    {
        goGoRunManager.onGameStart -= () => isGameStart = true;

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
            ScrollFloor();
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
    }

    private void ScrollFloor()
    {
        Vector3 floorPos = floor.position;
        Vector3 nextFloorPos = Vector3.left * (speed * 0.1f * backgrounds[CurUnitOfTime].Length) * Time.deltaTime;

        floor.position = floorPos + nextFloorPos;

        if (floor.position.x <= -18.0f)
        {
            floor.position = Vector3.zero;
        }
    }
    private void ChangeUnitOfTime()
    {
        for(int i = 0; i < unitOfBackgrounds.Length; i++)
        {
            unitOfBackgrounds[i].gameObject.SetActive(i == CurUnitOfTime);
        }
    }
}
