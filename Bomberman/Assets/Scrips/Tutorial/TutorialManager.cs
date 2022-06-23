using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bomberman
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;

        void Update()
        {
            Time.timeScale = 0f;
        }

        public void Skip()
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
        }

    }
}