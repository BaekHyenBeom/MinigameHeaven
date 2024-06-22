using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoGoRunController : MonoBehaviour, IController
{
    private Vector2 dir;

    private void FixedUpdate()
    {
        
    }

    #region Controller Default Frame 

    public void ConnetEvent(Character character)
    {
        throw new System.NotImplementedException();
    }

    public void DisConnectEvent(Character character)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>().normalized;
    }

    #endregion
}
