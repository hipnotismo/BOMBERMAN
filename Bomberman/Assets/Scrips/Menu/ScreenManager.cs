using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScreenManager : MonoBehaviour
{
    BackgroundMusic inst;

    public static Action setVolume;

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

#if UNITY_ANDRIOD

#endif
        Debug.Log("quit");
    }

    public void ReturnToLatScene()
    {
        Debug.Log("Options");
        Debug.Log(PlayerPrefs.GetString("LastScene"));

        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    //    inst.SetVolume();
    }
}
