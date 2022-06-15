using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool GameIsPause;
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
        Debug.Log("yes");
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }


}
