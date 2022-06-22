using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    
    void Update()
    {
        Time.timeScale = 0f;
    }

    public void Skip()
    {
        Time.timeScale = 1f;
        Canvas.SetActive(false);
    }

}
