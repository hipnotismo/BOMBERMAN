using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace bomberman
{
    public class VolumeOptions : MonoBehaviour
    {
        [SerializeField] AudioMixer mixer;
        [SerializeField] private Slider musicVolume;
        [SerializeField] private Slider FXVolume;

        public const string MIXER_MUSIC = "MusicVolume";
        public const string MIXER_SFX = "SFXVolume";

        void Awake()
        {
            musicVolume.onValueChanged.AddListener(SetMusicVolume);
            FXVolume.onValueChanged.AddListener(SetSFXVolume);

        }

        void Start()
        {
            musicVolume.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1F);
            FXVolume.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1F);

        }
        private void OnDisable()
        {
            PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicVolume.value);
            PlayerPrefs.SetFloat(AudioManager.SFX_KEY, FXVolume.value);

        }

        void SetMusicVolume(float value)
        {
            mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        }
        void SetSFXVolume(float value)
        {
            mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        }
    }
}