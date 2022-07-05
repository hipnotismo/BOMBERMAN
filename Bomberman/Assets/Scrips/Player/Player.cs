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
        }

        void Update()
        {
            Debug.Log(Time.timeScale);
          
          if (Input.GetKeyDown(KeyCode.P))
          {
                OnPauseButton?.Invoke();
          }          
            movement.Movement();
        }       

    }
}