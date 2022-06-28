using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace bomberman
{
    public class VolumeManager : MonoBehaviour
    {
        BackgroundMusic inst;

        [SerializeField] private Slider volume;
        [SerializeField] private Slider FXvolume;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
        void Start()
        {
            volume.value = PlayerPrefs.GetFloat("MusicVolume");
            FXvolume.value = PlayerPrefs.GetFloat("FXvolume");
        }

        public void SaveVolumes()
        {
            PlayerPrefs.SetFloat("MusicVolume", volume.value);
            PlayerPrefs.SetFloat("FXvolume", FXvolume.value);      
            BackgroundMusic.inst.SetVolume();
        }
    }
}
