using UnityEngine;
using UnityEngine.SceneManagement;

namespace bomberman
{
    public class ScreenManager : MonoBehaviour
    {

        public void Button(string name)
        {
            AudioManager.inst.ClickClips();

            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(name);
        }

        public void ExitButton()
        {

            AudioManager.inst.ClickClips();
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif            
        }

        public void ReturnToLatScene()
        {
            Debug.Log(PlayerPrefs.GetString("LastScene"));

            SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
            AudioManager.inst.ClickClips();

        }

        public void PlayClip()
        {
            AudioManager.inst.ClickClips();
        }
    }
    
}
