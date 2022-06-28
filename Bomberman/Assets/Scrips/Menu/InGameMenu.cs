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
            Debug.Log(SceneManager.GetActiveScene().name);

        }

        public void Reset()
        {
            Time.timeScale = 1f;
            Debug.Log("Reset");
            click.Play();
            OnRessetButton?.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        public void ExitButton()
        {
            Application.Quit();
            Debug.Log("quit");
        }

        public void Options()
        {
            OnRessetButton?.Invoke();
            Time.timeScale = 1f;
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Options");
        }
    }
}
