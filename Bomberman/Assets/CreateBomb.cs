using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform playerPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("bomb");
            Instantiate(bomb, playerPos.position , playerPos.rotation);
        }
    }
}
