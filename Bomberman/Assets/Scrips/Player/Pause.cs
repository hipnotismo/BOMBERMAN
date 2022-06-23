using UnityEngine;

namespace bomberman
{
    public class Pause : MonoBehaviour
    {
        private static bool GameIsPause;

      
        private void OnDestroy()
        {
            Player.OnPauseButton -= PauseState;
        }
        void Start()
        {
            Player.OnPauseButton += PauseState;        
            gameObject.SetActive(false);

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
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            GameIsPause = false;
        }

        private void IsPause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }
}