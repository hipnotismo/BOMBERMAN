using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{

    public void button(string name)
    {
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

 
}
