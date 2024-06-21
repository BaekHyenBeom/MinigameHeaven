using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSButton : MonoBehaviour
{
    public Image enableBtn;
    public Image disableBtn;
    public FPSType curType;

    public Sprite enableUI;
    public Sprite disableUI;


    private void OnEnable()
    {
        if (SettingManager.Instance.settings.fpsType == curType)
        {
            enableBtn.sprite = enableUI;
        }
        else
        {
            enableBtn.sprite = disableUI;
        }
    }

    public void SetFPS()
    {
        SoundUtil.ButtonSound();
        SettingManager.Instance.SettingFPS(curType, enableBtn, disableBtn, enableUI, disableUI);
    }
}