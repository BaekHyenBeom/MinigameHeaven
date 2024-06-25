using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeJumpController : MonoBehaviour, IController
{
    public Rigidbody2D rigid;
    public float curMovementInput;
    private int canJumpCount = 1;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && canJumpCount > 0)
        {
            if (Time.timeScale == 0.0f) { return; }

            canJumpCount--;
            SoundManager.Instance.PlaySfxSound("Jump");
            // SoundManager.Instance.PlaySfxSound("Jump");
            rigid.velocity = new Vector2 (rigid.velocity.x, 0f);
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Level"))
        {
            canJumpCount = 1;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void ConnetEvent(Character character)
    {
        throw new NotImplementedException();
    }

    public void DisConnectEvent(Character character)
    {
        throw new NotImplementedException();
    }
}
