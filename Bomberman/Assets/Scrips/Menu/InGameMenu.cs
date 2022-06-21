using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {

        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        Debug.Log("Reset");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void Options()
    {
        Debug.Log("Options");
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");

    }
}
