using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace bomberman
{
    public class Pause : MonoBehaviour
    {
        private static bool GameIsPause;
        [SerializeField] private GameObject pauseMenu;

        private void OnEnable()
        {
            Player.OnPauseButton += PauseState;
        }

        private void OnDisable()
        {
            Player.OnPauseButton -= PauseState;
        }
        void Start()
        {
            pauseMenu.SetActive(false);
            GameIsPause = false;
            pauseMenu.GetComponent<Canvas>();
            Debug.Log("Pause");

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                //if (GameIsPause)
                //{
                //    Resume();
                //}
                //else
                //{
                //    IsPause();
                //}
            }
        }

        void PauseState()
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                IsPause();
            }
        }
        private void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPause = false;
        }

        private void IsPause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }
}