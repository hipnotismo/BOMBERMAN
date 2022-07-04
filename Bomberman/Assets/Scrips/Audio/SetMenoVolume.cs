using System;
using UnityEngine;

namespace bomberman
{
    public class SetMenoVolume : MonoBehaviour
    {
       [SerializeField] AudioSource click;

        private void Awake()
        {
            click.volume= PlayerPrefs.GetFloat("FXvolume");
        }
    }
}