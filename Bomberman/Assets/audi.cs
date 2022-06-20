using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audi : MonoBehaviour
{
    string m_Path;
    void Start()
    {
        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("dataPath : " + m_Path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
