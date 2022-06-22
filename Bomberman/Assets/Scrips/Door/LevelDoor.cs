using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] private GameObject WinMenu;

    private bool active;
    private void OnEnable()
    {
        GameManager.EnableDoor += Enable;
    }

    private void OnDisable()
    {
        GameManager.EnableDoor -= Enable;

    }
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (active == true)
        {
            Debug.Log("It open");
            WinMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("not open");

        }
    }

    private void Enable()
    {
        active = true;
    }
}
