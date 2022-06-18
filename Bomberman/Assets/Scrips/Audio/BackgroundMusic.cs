using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    public static BackgroundMusic inst;

    private void Awake()
    {
        if (BackgroundMusic.inst == null)
        {
            BackgroundMusic.inst = this;
            DontDestroyOnLoad(gameObject);
            _music = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
