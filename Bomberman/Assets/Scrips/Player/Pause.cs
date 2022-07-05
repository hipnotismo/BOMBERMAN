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
            //Player.OnPauseButton += PauseState;
            //InGameMenu.OnRessetButton += Resume;

        }

        private void OnEnable()
        {
            Player.OnPauseButton += PauseState;
            InGameMenu.OnRessetButton += Resume;
        }
        private void OnDestroy()
        {
            ActivePanel(false);
            Player.OnPauseButton -= PauseState;
            InGameMenu.OnRessetButton -= Resume;
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
                SetPause();
            }
        }

        private void Resume()
        {
            ActivePanel(false);
            Time.timeScale = 1f;
            GameIsPause = false;
            Debug.Log(Time.timeScale);

        }

        private void SetPause()
        {
            ActivePanel(true);
            Time.timeScale = 0f;
            GameIsPause = true;
            Debug.Log(Time.timeScale);
        }
    }
}