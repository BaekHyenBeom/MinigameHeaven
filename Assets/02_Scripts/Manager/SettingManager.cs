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
        // ���� ����
        Application.targetFrameRate = (int)settings.fpsType;
        SoundManager.Instance.bgmSource.volume = settings.bgmValue;
        SoundManager.Instance.sfxSource.volume = settings.sfxValue;
    }

    public void SettingBGM(float value)
    {
        settings.bgmValue = value;
        // ���� �Ŵ����� �ݿ�
        SoundManager.Instance.bgmSource.volume = settings.bgmValue;

        //Debug.Log($"���� BGM ũ�� : {settings.bgmValue}");
    }

    public void SettingSFX(float value)
    {
        settings.sfxValue = value;
        // ���� �Ŵ����� �ݿ�
        SoundManager.Instance.sfxSource.volume = settings.sfxValue;

        //Debug.Log($"���� SFX ũ�� : {settings.sfxValue}");
    }

    public void SettingFPS(FPSType type, Image enableBtn, Image disableBtn, Sprite enable, Sprite disable)
    {
        enableBtn.sprite = enable;
        disableBtn.sprite = disable;
        settings.fpsType = type;

        Application.targetFrameRate = (int)settings.fpsType;
        //Debug.Log($"���� ������ �ӵ� {Application.targetFrameRate}");
    }
}
