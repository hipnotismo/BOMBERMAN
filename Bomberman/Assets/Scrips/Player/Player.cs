using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Action OnPauseButton;

    //private void OnEnable()
    //{
        
    //}

    //private void OnDisable()
    //{
        
    //}

    void Start()
    {
        Debug.Log("Stazrts");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("player press");
            OnPauseButton();
        }

    }

}
