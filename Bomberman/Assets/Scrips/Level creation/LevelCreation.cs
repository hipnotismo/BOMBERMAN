using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    private int cant = 3;

    void Start()
    {
        for (int i = 0; i < cant; i++)
        {
            Instantiate(wall, new Vector3(i,0,0), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
