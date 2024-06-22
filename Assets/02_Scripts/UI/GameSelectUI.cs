using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectUI : MonoBehaviour
{
    public GameObject targetUI;

    public void OpenUIAndInitSelect()
    {
        SoundUtil.SfxSound("ButtonSound");
        targetUI.SetActive(true);
        GameManager.Instance.curMinigame = MiniGameType.None;
        GameManager.Instance.curMinigameName = null;
        GameManager.Instance.CallMinigameDescUI();
    }
}
