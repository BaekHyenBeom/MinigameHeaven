using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSButton : MonoBehaviour
{
    public Image enableBtn;
    public Image disableBtn;
    public FPSType curType;

    private Color disableColor = new Color(0.5f, 0.5f, 0.5f);
    private Color enableColor = new Color(1f, 1f, 1f);


    private void OnEnable()
    {
        if (SettingManager.Instance.settings.fpsType == curType)
        {
            enableBtn.color = enableColor;
        }
        else
        {
            enableBtn.color = disableColor;
        }
    }

    public void SetFPS()
    {
        SoundUtil.ButtonSound();
        SettingManager.Instance.SettingFPS(curType, enableBtn, disableBtn);
    }
}