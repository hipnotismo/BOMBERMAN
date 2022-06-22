using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour, IDamageable
{

    public static Action OnBoxSpawned;

    private void Start()
    {
        OnBoxSpawned?.Invoke();
    }

    public void takeDamage()
    {
        Destroy(gameObject);
    }
}
