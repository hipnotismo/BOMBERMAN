using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDoor : MonoBehaviour
{

    private bool active;
    private void OnEnable()
    {
        GameManager.EnableDoor += Enable;
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
