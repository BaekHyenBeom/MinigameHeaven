using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundUtil
{
    public static void ButtonSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayButtonSound();
        }
    }
    public static void ErrorSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayErrorSound();
        }
    }
    public static void StartSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayStartSound();
        }
    }
}
