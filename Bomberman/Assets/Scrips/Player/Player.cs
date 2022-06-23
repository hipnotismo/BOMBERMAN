using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Action OnPauseButton;
    public static Action OnLoseGame;

    private int lifes;
    void Start()
    {
        lifes = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPauseButton();
        }

        if (lifes <= 0)
        {

        }
    }

}
