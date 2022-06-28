using UnityEngine;
using UnityEngine.SceneManagement;

namespace bomberman
{
    public class InGameMenu : MonoBehaviour
    {
        public AudioSource click;

        public void ReturnToMenu()
        {

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

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        public void ExitButton()
        {
            Application.Quit();
            Debug.Log("quit");
        }

        public void Options()
        {
            Time.timeScale = 1f;
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Options");
        }
    }
}
