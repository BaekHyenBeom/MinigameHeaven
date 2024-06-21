using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public bool isBGM;
    public Slider curSlider;

    private void OnEnable()
    {
        if (isBGM)
        {
            curSlider.value = SettingManager.Instance.settings.bgmValue;
        }
        else
        {
            curSlider.value = SettingManager.Instance.settings.sfxValue;
        }
    }

    public void ChangeBGMValue(float value)
    {
        SettingManager.Instance.SettingBGM(value);
    }

    public void ChangeSFXValue(float value)
    {
        SettingManager.Instance.SettingSFX(value);
    }
}
