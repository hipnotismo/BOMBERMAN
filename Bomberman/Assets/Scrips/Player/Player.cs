using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Action OnPauseButton;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void Start()
    {
        Debug.Log("Stazrts");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Working");
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPauseButton();
        }

    }

}
