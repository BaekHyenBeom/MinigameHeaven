using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoGoRunController : MonoBehaviour, IController
{
    [SerializeField]
    Rigidbody2D rd2D;

    public GoGoRunCharacter character;

    private bool isStart = false;

    private bool isCrouch = false;
    public float jumpPower = 6.0f;

    private int canJumpCount = 1;
    private void Awake()
    {
        character = GetComponent<GoGoRunCharacter>();
        TryGetComponent(out rd2D);
    }
    private IEnumerator Start()
    {
        jumpPower = 6.0f;
        yield return new WaitUntil(() => GameManager.Instance.curMiniGameScript != null);
        GameManager.Instance.curMiniGameScript.OnStart += CanMove;
        GameManager.Instance.curMiniGameScript.OnPause += CantMove;
    }
    #region Controller Default Frame 


    private void CanMove() => isStart = true;
    private void CantMove() => isStart = false;


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
            if(canJumpCount > 0)
            {
                if (context.phase == InputActionPhase.Started && !isCrouch)
                {
                    canJumpCount--;
                    SoundManager.Instance.PlaySfxSound("Jump");
                    rd2D.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                }
            }

        }

    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (isStart)
        {
            if (context.phase == InputActionPhase.Started && canJumpCount > 0)
            {
                isCrouch = true;
                SoundManager.Instance.PlaySfxSound("Crouch");
                character.CrouchAnim(true);
            }

            else if (context.phase == InputActionPhase.Canceled && canJumpCount > 0)
            {
                isCrouch = false;
                SoundManager.Instance.PlaySfxSound("CrouchUp");
                character.CrouchAnim(false);
            }
        }

    }
    public void OnMove(InputAction.CallbackContext context)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Level"))
        {
            canJumpCount = 1;
        }
    }


    #endregion
}
