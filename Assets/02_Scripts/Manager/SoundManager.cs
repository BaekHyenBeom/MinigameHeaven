using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("SoundClip Setting")]
    public Sound[] bgmSounds;
    public Sound[] sfxSounds;

    public void PlayBgm(string name)
    {
        Sound s = Array.Find(bgmSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("���尡 �����ϴ�.");
        }
        else
        {
            bgmSource.loop = true; // <-- �䷸��
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }

    public void PlaySfxSound(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("���尡 �����ϴ�.");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
