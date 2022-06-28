using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bomberman {
    public class LoseUI : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();

        }
        void Start()
        {
            PlayerLife.OnPlayerDeath += ActiveLoseCanvas;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        private void OnDestroy()
        {
            PlayerLife.OnPlayerDeath -= ActiveLoseCanvas;

        }
        // Update is called once per frame
        void ActiveLoseCanvas()
        {
            canvasGroup.alpha = 1;
            Time.timeScale = 0;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }


    }
}