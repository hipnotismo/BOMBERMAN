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

    }

    public void Reset()
    {
        Debug.Log("Reset");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
