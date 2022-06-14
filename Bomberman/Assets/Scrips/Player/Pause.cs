using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private static bool GameIsPause = false;

    void Start()
    {
        
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

    public void Resume()
    {
       // PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    private void Pouse()
    {
   // PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
