using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void button(string name)
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(name);
    }

    public void exitButton()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_ANDRIOD

#endif
        Debug.Log("quit");
    }

    public void returnToLatScene()
    {
        Debug.Log("Options");
        Debug.Log(PlayerPrefs.GetString("LastScene"));

        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    }
}
