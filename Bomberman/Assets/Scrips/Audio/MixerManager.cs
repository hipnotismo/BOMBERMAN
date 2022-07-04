using UnityEngine;
using UnityEngine.Audio;
using System;

namespace bomberman
{
    public class MixerManager : MonoBehaviour
    {
        [SerializeField] AudioMixer mixer;

        private void OnEnable()
        {
        }

        void SetMixerVolume()
        {
          //  mixer.SetFloat();
        }
    }
}