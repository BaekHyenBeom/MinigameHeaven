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

        Debug.Log($"���� SFX ũ�� : {settings.bgmValue}");
    }

    public void SettingSFX(float value)
    {
        settings.sfxValue = value;
        // ���� �Ŵ����� �ݿ�
        SoundManager.Instance.sfxSource.volume = settings.sfxValue;

        Debug.Log($"���� SFX ũ�� : {settings.sfxValue}");
    }

    public void SettingFPS(FPSType type, Image enableBtn, Image disableBtn)
    {
        enableBtn.color = enableColor;
        disableBtn.color = disableColor;
        settings.fpsType = type;

        Application.targetFrameRate = (int)settings.fpsType;
        Debug.Log($"���� ������ �ӵ� {Application.targetFrameRate}");
    }
}
