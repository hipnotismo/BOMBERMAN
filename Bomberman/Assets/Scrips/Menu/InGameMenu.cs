using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace bomberman
{
    public class InGameMenu : MonoBehaviour
    {
        public static Action OnRessetButton;

        public void ReturnToMenu()
        {
            AudioManager.inst.ClickClips();
            OnRessetButton?.Invoke();
            SceneManager.LoadScene("MainMenu");
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;

        }

        public void Reset()
        {
            AudioManager.inst.ClickClips();
            Time.timeScale = 1f;
            OnRessetButton?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        public void ExitButton()
        {
            AudioManager.inst.ClickClips();
            Application.Quit();
        }

        public void Options()
        {
            AudioManager.inst.ClickClips();
            OnRessetButton?.Invoke();
            Time.timeScale = 1f;
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Options");
        }

        public void ClickPlay()
        {
            AudioManager.inst.ClickClips();
        }
    }
}
