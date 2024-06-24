using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType
{
    Top,
    Bottom,
    Both,
}

public class Trap : MonoBehaviour
{

    [field : SerializeField]
    protected Animator animator;

    public TrapType trapType = TrapType.Top;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("게임 오버");
        }
    }
}
