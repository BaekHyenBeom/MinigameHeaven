using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoRunCharacter : Character
{
    private readonly int hashRun = Animator.StringToHash("isRun");
    private readonly int hashHit = Animator.StringToHash("isHit");

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    public override void GameOverAnim()
    {
        base.GameOverAnim();
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


}
