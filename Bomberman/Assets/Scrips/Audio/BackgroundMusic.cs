using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    public static BackgroundMusic inst;

    private void Awake()
    {
        if (BackgroundMusic.inst == null)
        {
           // PlayerPrefs.SetFloat("MusicVolume", 1f);
            BackgroundMusic.inst = this;
            DontDestroyOnLoad(gameObject);
            _music = GetComponent<AudioSource>();
            _music.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SetVolume()
    {
        _music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
