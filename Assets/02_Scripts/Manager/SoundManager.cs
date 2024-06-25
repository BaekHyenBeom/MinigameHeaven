using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            bgmSource.Stop();
            bgmSource.clip = null;
        }
    }

    public void PlayBgm(string name)
    {
        Sound s = Array.Find(bgmSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("사운드가 없습니다.");
        }
        else
        {
            bgmSource.loop = true; // <-- 요렇게
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }

    public void PlaySfxSound(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("사운드가 없습니다.");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void StopBgm()
    {
        if(bgmSource.isPlaying)
            bgmSource.Stop();
    }
    
    ~SoundManager()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
