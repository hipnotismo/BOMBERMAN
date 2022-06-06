using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    private int BlockCount;
    void Start()
    {
        BlockCount = 0;
        Debug.Log("count is "+ BlockCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (BlockCount == 7)
        {

        }
    }

    public void Increase()
    {
        BlockCount++;
    }
}
