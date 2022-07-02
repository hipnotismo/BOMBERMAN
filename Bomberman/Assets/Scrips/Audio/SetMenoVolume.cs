using System;
using UnityEngine;

namespace bomberman
{
    public class SetMenoVolume : MonoBehaviour
    {
       [SerializeField] AudioSource click;
       [SerializeField] AudioSource explosion;

        private void Awake()
        {
            click.volume= PlayerPrefs.GetFloat("FXvolume");
        }
    }
}