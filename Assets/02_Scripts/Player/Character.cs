using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public MiniGameManager curMiniGame; // ���� ���� ���� ������

    [Header("Basic Setting")]
    public Controller curController;
    public CharacterSO curCharacter;
    public Animator curAnimator;
    
    // ĳ���� �������� Controller���� �ذ��ؾߵȴ�;;
    // �ִϸ����� �κп��� ���� �ٸ� �� ������;;
    public void DoingMove()
    {
    }

    public void DoingJump()
    {
    }
}
