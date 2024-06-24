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

    void Start()
    {
        // 기초 세팅
        Application.targetFrameRate = (int)settings.fpsType;
        SoundManager.Instance.bgmSource.volume = settings.bgmValue;
        SoundManager.Instance.sfxSource.volume = settings.sfxValue;
    }

    public void SettingBGM(float value)
    {
        settings.bgmValue = value;
        // 사운드 매니저에 반영
        SoundManager.Instance.bgmSource.volume = settings.bgmValue;

        //Debug.Log($"현재 BGM 크기 : {settings.bgmValue}");
    }

    public void SettingSFX(float value)
    {
        settings.sfxValue = value;
        // 사운드 매니저에 반영
        SoundManager.Instance.sfxSource.volume = settings.sfxValue;

        //Debug.Log($"현재 SFX 크기 : {settings.sfxValue}");
    }

    public void SettingFPS(FPSType type, Image enableBtn, Image disableBtn, Sprite enable, Sprite disable)
    {
        enableBtn.sprite = enable;
        disableBtn.sprite = disable;
        settings.fpsType = type;

        Application.targetFrameRate = (int)settings.fpsType;
        //Debug.Log($"현재 프레임 속도 {Application.targetFrameRate}");
    }
}
