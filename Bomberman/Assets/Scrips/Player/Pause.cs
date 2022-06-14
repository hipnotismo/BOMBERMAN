using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool GameIsPause = false;

    [SerializeField] private GameObject PauseMenu;
   
    void Start()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pouse();
            }
        }
    }

    private void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    private void Pouse()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public  void ReturnToMenu()
    {
        
        SceneManager.LoadScene("MainMenu");

    }

    public void Reset()
    {
        Debug.Log("Reset");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
