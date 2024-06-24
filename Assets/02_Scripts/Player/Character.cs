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
        Debug.Log("�������� ����.");
    }

    public virtual void MoveAnim()
    {
        Debug.Log("�������� ����.");
    }

    public virtual void JumpAnim()
    {
        Debug.Log("�������� ����.");
    }

    public virtual void HitAnim()
    {
        Debug.Log("�������� ����.");
    }

    public virtual void GameOverAnim()
    {
        Debug.Log("�������� ����.");
    }
}
