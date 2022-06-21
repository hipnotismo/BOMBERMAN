using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private Text lifesLeft;

    void Start()
    {
        lifesLeft.text = PlayerPrefs.GetInt("PlayerLife").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lifesLeft.text = "Lifes left: " + PlayerPrefs.GetInt("PlayerLife").ToString();
    }
}
