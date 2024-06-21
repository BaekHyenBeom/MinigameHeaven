using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartUI : MonoBehaviour
{
    public void GameStart()
    {
        if (GameManager.Instance.curCharacter == null)
        {
            Debug.Log("ĳ���͸� �������� �ʾҽ��ϴ�!");
            return;
        }
        if (GameManager.Instance.curMinigame != MiniGameType.None)
        {
            SceneManager.LoadScene($"{GameManager.Instance.curMinigame}Scene");
        }
        else
        {
            Debug.Log("�̴� ������ �������� �ʾҽ��ϴ�!");
            return;
        }
    }
}
