using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace bomberman
{
    public class ScreenManager : MonoBehaviour
    {
        BackgroundMusic inst;
        float quitTime = 1;
        float quitTimer = 0;
        private void OnEnable()
        {
        }
        public void Button(string name)
        {
            StartCoroutine(ButtonTimner(name));

        }

        public void ExitButton()
        {

            StartCoroutine(QuitTimer());
            
        }

        public void ReturnToLatScene()
        {
            StartCoroutine(ScenneChangeTimer());

        }

        IEnumerator QuitTimer()
        {
            while (quitTimer < quitTime)
            {
                quitTimer += Time.deltaTime;
                yield return null;
            }

            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Debug.Log("quit");
        }

        IEnumerator ScenneChangeTimer()
        {
            while (quitTimer < quitTime)
            {
                quitTimer += Time.deltaTime;
                yield return null;
            }
            Debug.Log("Options");
            Debug.Log(PlayerPrefs.GetString("LastScene"));

            SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
        }

        IEnumerator ButtonTimner(string name)
        {
            while (quitTimer < quitTime)
            {
                quitTimer += Time.deltaTime;
                yield return null;
            }
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(name);
        }
    }
    
}
