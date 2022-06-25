using UnityEngine;

namespace bomberman
{
    public class Pause : MonoBehaviour
    {
        private static bool GameIsPause;
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        void Start()
        {
            Player.OnPauseButton += PauseState;
            ActivePanel(false);
        }

        private void OnDestroy()
        {
            Player.OnPauseButton -= PauseState;
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
        void PauseState()
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                IsPause();
            }
        }

        private void Resume()
        {
            ActivePanel(false);
            Time.timeScale = 1f;
            GameIsPause = false;
        }

        private void IsPause()
        {
            ActivePanel(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }
}