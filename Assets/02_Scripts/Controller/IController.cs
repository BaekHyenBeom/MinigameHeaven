using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IController
{
    // 캐릭터 집어 넣으시고 Controller가 Character의 Rigidbody를 건들게 됩니다
    public void ConnetEvent(Character character);
    public void DisConnectEvent(Character character);
    public void OnJump(InputAction.CallbackContext context);
    public void OnMove(InputAction.CallbackContext context);
}
