using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���⼭ �ۼ��Ͻ��� ���� �̰��� ��ӹ����ż� Ŭ������ ����ž��մϴ�!
public class Character : MonoBehaviour
{
    public MiniGameManager curMiniGame; // ���� ���� ���� ������

    [Header("Basic Setting")]
    public IController curController; // Controller���� ����
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
