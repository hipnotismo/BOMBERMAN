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
        Debug.Log("quit");
    }
}
