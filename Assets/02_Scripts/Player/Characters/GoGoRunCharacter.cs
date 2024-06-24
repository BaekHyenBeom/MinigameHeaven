using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoRunCharacter : Character
{
    private readonly int hashRun = Animator.StringToHash("isRun");
    private readonly int hashHit = Animator.StringToHash("isHit");
    private readonly int hashCrouch = Animator.StringToHash("isCrouch");


    IEnumerator Start()
    {
        yield return new WaitUntil(() => GameManager.Instance.curMiniGameScript != null);

        GameManager.Instance.curMiniGameScript.OnStart += MoveAnim;
    }

    public override void GameOverAnim()
    {
        base.GameOverAnim();
        HitAnim();
    }

    public override void HitAnim()
    {
        base.HitAnim();
        curAnimator.SetTrigger(hashHit);
    }

    public override void IdleAnim()
    {
        base.IdleAnim();
        curAnimator.SetBool(hashRun, false);
    }


    public override void MoveAnim()
    {
        base.MoveAnim();

        curAnimator.SetBool(hashRun, true);
    }

    public void CrouchAnim(bool active)
    {
        curAnimator.SetBool(hashCrouch, active);
    }


}
