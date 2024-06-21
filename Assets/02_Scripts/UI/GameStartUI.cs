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

    public void GameStart()
    {
        if (GameManager.Instance.curCharacter == null)
        {
            SoundUtil.SfxSound("ErrorSound");
            AlertTxt("ĳ���͸� �����ϼ���!");
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
            AlertTxt("�̴ϰ����� �����ϼ���!");
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
