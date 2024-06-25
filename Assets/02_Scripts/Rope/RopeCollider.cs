using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollider : MonoBehaviour
{
    public RopeJumpMiniGameManager ropeJumpMiniGameManager;
    public Collider2D collider;
    public SpriteRenderer sprite;
    float curFrame = 30.0f; // ȯ�漳�� �����Ӱ� �����ؼ� ����
    float curSpeed = 30.0f;
    
    void Start()
    {
        StartCoroutine(CurSpeedChange());
        StartCoroutine(ActiveRope());
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

    private IEnumerator ActiveRope()
    {
        while (true)
        {
            collider.enabled = true; sprite.enabled = true;
            yield return new WaitForSeconds(0.25f);
            collider.enabled = false; sprite.enabled = false;
            ropeJumpMiniGameManager.curScore++;
            yield return new WaitForSeconds(curSpeed);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� ����!");
            ropeJumpMiniGameManager.GameOver();
        }
    }
}
