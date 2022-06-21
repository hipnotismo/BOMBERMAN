using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name);

    }

    public void Reset()
    {
        Debug.Log("Reset");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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
