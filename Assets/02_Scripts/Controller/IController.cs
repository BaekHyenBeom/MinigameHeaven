using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IController
{
    // ĳ���� ���� �����ð� Controller�� Character�� Rigidbody�� �ǵ�� �˴ϴ�
    public void ConnetEvent(Character character);
    public void DisConnectEvent(Character character);
    public void OnJump(InputAction.CallbackContext context);
    public void OnMove(InputAction.CallbackContext context);
}