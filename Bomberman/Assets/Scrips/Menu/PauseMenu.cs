using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
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
}
