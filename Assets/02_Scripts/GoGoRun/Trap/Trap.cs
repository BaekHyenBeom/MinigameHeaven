using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Trap : MonoBehaviour
{
    [field : SerializeField]
    protected Animator animator;

    public LayerMask layerMask;

    public float moveSpeed = 2.5f;

    public float checkRate = 0.05f;
    private float lastCheckTime;

    public Transform rayPos;

    RaycastHit2D hit;
    private void Start()
    {
        moveSpeed = 2.0f;
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            hit = Physics2D.Raycast(rayPos.position, Vector2.left, 2.0f, layerMask);

            if (hit)
            {
                if (hit.Equals(this))
                {
                    return;
                }
                else
                {
                    moveSpeed = 0f;
                }
            }
            else
            {
                moveSpeed = 2.5f;
            }
        }

    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.curMiniGameScript.GameOver();
        }
    }
}
