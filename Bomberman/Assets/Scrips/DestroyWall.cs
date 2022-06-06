using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour, Iterface
{
   
    public void damageable()
    {
        Destroy(gameObject);
    }
}
