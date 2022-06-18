using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    [SerializeField] private Slider volume;
    [SerializeField] private Slider FXvolume;
    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
        FXvolume.value = PlayerPrefs.GetFloat("FXvolume");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", volume.value);
        PlayerPrefs.SetFloat("FXvolume", FXvolume.value);

    }
}
