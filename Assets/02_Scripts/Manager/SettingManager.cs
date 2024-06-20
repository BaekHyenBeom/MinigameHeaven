using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FPSType
{ 
    FPS30 = 30,
    FPS60 = 60
}

public class SettingManager : Singleton<SettingManager>
{
    public SettingSO settings;

    private Color disableColor = new Color(0.5f, 0.5f, 0.5f);
    private Color enableColor = new Color(1f, 1f, 1f);

    void Start()
    {
        // 기초 세팅
        Application.targetFrameRate = (int)settings.fpsType;
    }

    public void SettingBGM(float value)
    {
        settings.bgmValue = value;
        // 사운드 매니저에 반영

        Debug.Log($"현재 SFX 크기 : {settings.bgmValue}");
    }

    public void SettingSFX(float value)
    {
        settings.sfxValue = value;
        // 사운드 매니저에 반영

        Debug.Log($"현재 SFX 크기 : {settings.sfxValue}");
    }

    public void SettingFPS(FPSType type, Image enableBtn, Image disableBtn)
    {
        enableBtn.color = enableColor;
        disableBtn.color = disableColor;
        settings.fpsType = type;

        Application.targetFrameRate = (int)settings.fpsType;
        Debug.Log($"현재 프레임 속도 {Application.targetFrameRate}");
    }
}
