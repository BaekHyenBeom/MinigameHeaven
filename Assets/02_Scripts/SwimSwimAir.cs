using System;
using UnityEngine;
using UnityEngine.UI;

public class SwimSwimAir : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiBar;

    public SwimSwimMiniGameManager swimSwimMiniGameManager;

    public void Awake()
    {
        swimSwimMiniGameManager = GetComponent<SwimSwimMiniGameManager>();
    }

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
        Subtract(passiveValue * Time.deltaTime);

        if (curValue <= 0.0f)
        {
            // 산소가 고갈되면 게임 오버
            swimSwimMiniGameManager.GameOver();
        }
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 산소 보충
            Add(10);
        }
    }
}