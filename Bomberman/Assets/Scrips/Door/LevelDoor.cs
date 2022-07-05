using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace bomberman
{
    public class LevelDoor : MonoBehaviour
    {
        static public Action OnPlayerWin;

        private bool active;

        private void OnEnable()
        {
            GameManager.EnableDoor += Enable;
        }

        private void OnDisable()
        {
            GameManager.EnableDoor -= Enable;

        }
        void Start()
        {
            active = false;
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Player here");
            if (other.CompareTag("Player"))
            {
                if (active == true)
                {
                    OnPlayerWin?.Invoke();
                }             
            }   
        }

        private void Enable()
        {
            active = true;
        }
    }
}
