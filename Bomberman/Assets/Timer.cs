using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject,3.5f);
    }
}
