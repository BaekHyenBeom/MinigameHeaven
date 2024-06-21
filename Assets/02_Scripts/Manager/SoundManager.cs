using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("SoundClip Setting")]
    public AudioClip buttonSound;
    public AudioClip StartSound;
    public AudioClip ErrorSound;

    // Start is called before the first frame update

    public void PlayButtonSound()
    {
        sfxSource.PlayOneShot(buttonSound);
    }

    public void PlayStartSound()
    {
        sfxSource.PlayOneShot(StartSound);
    }

    public void PlayErrorSound()
    {
        sfxSource.PlayOneShot(ErrorSound);
    }
}
