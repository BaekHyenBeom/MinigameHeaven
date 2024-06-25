using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoRunDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trap"))
        {
            collision.gameObject.SetActive(false);
        }

    }
}
