using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour, IController
{
    public Rigidbody2D rigid;
    public float curMovementInput;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigid.AddForce(Vector2.right * curMovementInput * 1, ForceMode2D.Impulse);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if (Time.timeScale == 0.0f) { return; }
            rigid.velocity = new Vector2 (rigid.velocity.x, 0f);
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<float>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = 0f;
        }
    }
}
