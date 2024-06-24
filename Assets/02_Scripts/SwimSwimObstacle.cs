using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimSwimObstacle : MonoBehaviour
{
    public SwimSwimMiniGameManager swimSwimMiniGameManager;
    float curSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(CurSpeedChange());
    }

    private void Update()
    {
        transform.position += Vector3.left * curSpeed;
    }

    IEnumerator CurSpeedChange()
    {
        curSpeed = Random.Range(0.08f, 0.15f);
        yield return new WaitForSeconds(150.0f); // 5초마다 변속: 프레임이 30이라면 150, 60이라면 300
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("게임 오버!");
            swimSwimMiniGameManager.GameOver();
        }
    }
}
