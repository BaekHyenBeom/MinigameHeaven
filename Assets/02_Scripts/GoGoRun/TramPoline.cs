using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramPoline : Trap
{

    [SerializeField]
    private float power = 5f;

    private int hashTrigger = Animator.StringToHash("isJump");

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out Rigidbody2D rb))
            {
                animator.SetTrigger(hashTrigger);
                SoundManager.Instance.PlaySfxSound("Trampoline");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector3.up * power, ForceMode2D.Impulse);

            }
        }
    }

}
