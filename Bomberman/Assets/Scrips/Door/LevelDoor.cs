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

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
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
