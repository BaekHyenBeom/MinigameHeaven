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
            Debug.Log("캐릭터를 선택하지 않았습니다!");
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
            Debug.Log("미니 게임을 선택하지 않았습니다!");
            return;
        }
    }
}
