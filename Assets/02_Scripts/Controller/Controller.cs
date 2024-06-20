using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface Controller
{
    // ĳ���� ���� �����ð� Controller�� Character�� Rigidbody�� �ǵ�� �˴ϴ�
    public void OnJump(InputAction.CallbackContext context);
    public void OnMove(InputAction.CallbackContext context);
}
