using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

namespace bomberman
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager inst;

        [SerializeField] AudioMixer mixer;
        [SerializeField] AudioSource explosionSource;
        [SerializeField] List <AudioClip> explosionClips = new List<AudioClip>();
        [SerializeField] AudioSource clickSource;
        [SerializeField] List<AudioClip> clickClips = new List<AudioClip>();
        [SerializeField] AudioSource backgroundSource;


        public const string MUSIC_KEY = "MusicVolume";
        public const string SFX_KEY = "SFXVolume";

        private void Awake()
        {
            if (AudioManager.inst == null)
            {
                AudioManager.inst = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("Not Destroy");
                LoadVolume();
            }
            else
            {
                Debug.Log("Id destroy");
                Destroy(gameObject);
            }

        }

        private void Start()
        {
            PlayBackground();
        }

        public void ExplosionClips()
        {
            AudioClip clip = explosionClips[Random.Range(0, explosionClips.Count)];
            explosionSource.PlayOneShot(clip);
        }

        public void ClickClips()
        {
            AudioClip clip = clickClips[Random.Range(0, clickClips.Count)];
            clickSource.PlayOneShot(clip);
        }

        void LoadVolume() // volume save in VolumeOptions.cs
        {
            float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY,1f);
            float SFXVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
            Debug.Log(musicVolume);
            mixer.SetFloat(VolumeOptions.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
            mixer.SetFloat(VolumeOptions.MIXER_SFX, Mathf.Log10(SFXVolume) * 20);
            Debug.Log(PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1F));

        }

        void PlayBackground() 
        {
            backgroundSource.volume = PlayerPrefs.GetFloat(MUSIC_KEY);
            backgroundSource.Play();
        }
    }
}