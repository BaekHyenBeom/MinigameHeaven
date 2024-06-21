using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public bool isBGM;
    public Slider curSlider;

    private int checktime;
    Coroutine SoundChecking;
    bool isFirstSetting;

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
        if (isFirstSetting == false) { isFirstSetting = true; return; }
        SettingManager.Instance.SettingSFX(value);
        checktime = 2;
        if (SoundChecking == null) { SoundChecking = StartCoroutine(SoundCheck()); }
    }

    IEnumerator SoundCheck()
    {
        while(checktime > 0)
        {
            checktime--;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        SoundUtil.SfxSound("ButtonSound");
        SoundChecking = null;
    }
}
