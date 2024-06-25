using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollider : MonoBehaviour
{
    public Collider2D col;

    float curSpeed = 30.0f;

    private Coroutine coActiveRope;

    private void Start()
    {
        StartCoroutine(CurSpeedChange());
    }
    private IEnumerator CurSpeedChange()
    {
        while (true)
        {
            int curSpeedNum = Random.Range(0, 3);

            switch (curSpeedNum)
            {
                case 0: curSpeed = 2.0f; Debug.Log("����"); break;
                case 1: curSpeed = 1.5f; Debug.Log("����"); break;
                case 2: curSpeed = 1.0f; Debug.Log("����"); break;
                default: curSpeed = 1.5f; Debug.Log("����"); break;
            }

            yield return new WaitForSeconds(8.0f);
        }
    }

    public void ActiveRope() => col.enabled = true;

    public void SetScore() => GameManager.Instance.curMiniGameScript.curScore++;
    public void UnActiveRope() => col.enabled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� ����!");
            GameManager.Instance.curMiniGameScript.GameOver();
        }
    }
}
