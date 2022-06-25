using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bomberman {
    public class WinUI : MonoBehaviour
    {

        CanvasGroup canvasGroup;

        private void Awake()
        {
            LevelDoor.OnPlayerWin += OnWin;
            canvasGroup = GetComponent<CanvasGroup>();
        }
        void Start()
        {
            ActivePanel(false);

        }

        void OnWin() 
        {        
            Time.timeScale = 0;
            ActivePanel(true);
        }

        void ActivePanel(bool active)
        {
            if (active)
            {
                canvasGroup.alpha = 1;

            }
            else
            {
                canvasGroup.alpha = 0;
            }

            canvasGroup.interactable = active;
            canvasGroup.blocksRaycasts = active;
        }
    }
}