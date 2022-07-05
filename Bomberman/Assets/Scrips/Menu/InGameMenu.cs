using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace bomberman
{
    public class InGameMenu : MonoBehaviour
    {
        public AudioSource click;
        public static Action OnRessetButton;

        public void ReturnToMenu()
        {
            OnRessetButton?.Invoke();
            SceneManager.LoadScene("MainMenu");
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;

        }

        public void Reset()
        {
            Time.timeScale = 1f;
            click.Play();
            OnRessetButton?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void Options()
        {
            OnRessetButton?.Invoke();
            Time.timeScale = 1f;
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        }
    }
}
