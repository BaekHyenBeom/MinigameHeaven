using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public MiniGameManager curMiniGame; // 게임 오버 판정 때문에

    [Header("Basic Setting")]
    public Controller curController;
    public CharacterSO curCharacter;
    public Animator curAnimator;
    
    // 캐릭터 움직임은 Controller에서 해결해야된다;;
    // 애니메이터 부분에서 서로 다른 게 존재함;;
    public void DoingMove()
    {
    }

    public void DoingJump()
    {
    }
}
