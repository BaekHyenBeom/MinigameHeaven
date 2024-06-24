using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoGoRunController : MonoBehaviour, IController
{
    public GoGoRunManager gogoRunManager;
    [SerializeField]
    Rigidbody2D rd2D;

    private bool isStart = false;
    private void Awake()
    {
        TryGetComponent(out rd2D);
    }

    #region Controller Default Frame 

    private void OnEnable()
    {
        gogoRunManager.onGameStart += () => isStart = true;
    }
    private void OnDisable()
    {
        gogoRunManager.onGameStart += () => isStart = false;

    }


    public void ConnetEvent(Character character)
    {

    }

    public void DisConnectEvent(Character character)
    {

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isStart)
        {
            if (context.phase == InputActionPhase.Started)
            {
                rd2D.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
            }
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {

    }

    #endregion
}
