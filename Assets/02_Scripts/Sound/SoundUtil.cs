using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundUtil
{
    public static void SfxSound(string sfxname)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfxSound(sfxname);
        }
    }
}
