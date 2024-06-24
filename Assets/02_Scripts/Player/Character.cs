using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 여기서 작성하시지 말고 이것을 상속받으셔서 클래스를 만드셔야합니다!
public class Character : MonoBehaviour
{
    public MiniGameManager curMiniGame; // 게임 오버 판정 때문에

    [Header("Basic Setting")]
    public IController curController; // Controller와의 연결
    public CharacterSO curCharacter;
    public Animator curAnimator;

    public virtual void IdleAnim()
    {
    }

    public virtual void MoveAnim()
    {

    }

    public virtual void JumpAnim()
    {
    }

    public virtual void HitAnim()
    {
    }

    public virtual void GameOverAnim()
    {
    }
}
