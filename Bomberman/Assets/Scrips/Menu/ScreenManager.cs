using UnityEngine;
using UnityEngine.SceneManagement;

namespace bomberman
{
    public class ScreenManager : MonoBehaviour
    {
        BackgroundMusic inst;

        private void OnEnable()
        {

        }
        public void Button(string name)
        {
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(name);
        }

        public void ExitButton()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Debug.Log("quit");
        }

        public void ReturnToLatScene()
        {
            Debug.Log("Options");
            Debug.Log(PlayerPrefs.GetString("LastScene"));

            SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
        }
    }
}
