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
            SoundUtil.ErrorSound();
            Debug.Log("ĳ���͸� �������� �ʾҽ��ϴ�!");
            return;
        }
        if (GameManager.Instance.curMinigame != MiniGameType.None)
        {
            SoundUtil.StartSound();
            SceneManager.LoadScene($"{GameManager.Instance.curMinigame}Scene");
        }
        else
        {
            SoundUtil.ErrorSound();
            Debug.Log("�̴� ������ �������� �ʾҽ��ϴ�!");
            return;
        }
    }
}
