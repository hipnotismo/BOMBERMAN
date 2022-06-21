using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour, Interface
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
}
