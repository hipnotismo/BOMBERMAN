using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour, Iterface
{

    public static Action OnBoxSpawned;

    private void Start()
    {
        OnBoxSpawned?.Invoke();

    }

    public void damageable()
    {
        Destroy(gameObject);
    }

    public void Increase()
    {
        
    }
}
