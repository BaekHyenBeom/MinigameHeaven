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
            SoundUtil.SfxSound("ErrorSound");
            Debug.Log("ĳ���͸� �������� �ʾҽ��ϴ�!");
            return;
        }
        if (GameManager.Instance.curMinigame != MiniGameType.None)
        {
            SoundUtil.SfxSound("StartSound");
            SceneManager.LoadScene($"{GameManager.Instance.curMinigame}Scene");
        }
        else
        {
            SoundUtil.SfxSound("ErrorSound");
            Debug.Log("�̴� ������ �������� �ʾҽ��ϴ�!");
            return;
        }
    }
}
