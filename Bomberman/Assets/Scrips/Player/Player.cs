using UnityEngine;
using System;

namespace bomberman
{
    public class Player : MonoBehaviour
    {
        public static Action OnPauseButton;

        PlayerMovement movement;
        PlayerLife thisLife;
       
        void Start()
        {
            movement = GetComponent<PlayerMovement>();
            thisLife = GetComponent<PlayerLife>();
            Debug.Log("Stazrts");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("player press");

                OnPauseButton?.Invoke();
            }

            movement.Movement();
        }       

    }
}