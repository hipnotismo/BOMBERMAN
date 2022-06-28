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
            ActivePanel(false);
        }

        void Start()
        {
            Player.OnPauseButton += PauseState;
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
            Debug.Log(Time.timeScale);

        }

        private void IsPause()
        {
            ActivePanel(true);
            Time.timeScale = 0f;
            GameIsPause = true;
            Debug.Log(Time.timeScale);
            return;
        }


    }
}