using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartUI : MonoBehaviour
{
    public GameObject alertobj;
    public TextMeshProUGUI alertTxt;
    private int alertTime;

    [SerializeField] private List<string> miniGameScene;

    public void GameStart()
    {
        if (GameManager.Instance.curCharacter == null)
        {
            SoundUtil.SfxSound("ErrorSound");
            AlertTxt("캐릭터를 선택하세요!");
            return;
        }
        if (GameManager.Instance.curMinigame != MiniGameType.None)
        {
            SoundUtil.SfxSound("StartSound");
            switch(GameManager.Instance.curMinigame)
            {
                case MiniGameType.RopeJump:
                    SceneManager.LoadScene(miniGameScene[0]);
                    break;
                case MiniGameType.HighJump:
                    SceneManager.LoadScene(miniGameScene[1]);
                    break;
                case MiniGameType.GoGoRun:
                    SceneManager.LoadScene(miniGameScene[2]);
                    break;
                case MiniGameType.SwimSwim:
                    SceneManager.LoadScene(miniGameScene[3]);
                    break;
                default:
                    break;
            }
        }
        else
        {
            SoundUtil.SfxSound("ErrorSound");
            AlertTxt("미니게임을 선택하세요!");
            return;
        }
    }

    private void AlertTxt(string str)
    {
        if (alertTime == 0)
        {
            alertTime = 5;
            StartCoroutine(AlertCoroutine(str));
        }
        else
        {
            alertTime = 5;
        }
    }

    IEnumerator AlertCoroutine(string str)
    {
        alertobj.SetActive(true);
        alertTxt.text = str;
        while(alertTime > 0)
        {
            alertTime--;
            yield return new WaitForSeconds(0.1f);
        }
        alertobj.SetActive(false);
    }
}
