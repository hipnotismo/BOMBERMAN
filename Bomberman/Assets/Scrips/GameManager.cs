using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    int AmountOfBoxes;
    int DestroyedBoxes;

    public static Action EnableDoor;

    private void OnEnable()
    {
        DestroyWall.OnBoxSpawned += AddCount;
        DestroyBomb.OnBoxDestroyed += DestructionCount;
    }

    private void OnDisable()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (AmountOfBoxes == DestroyedBoxes)
        {
            EnableDoor?.Invoke();
        }
    }

    void AddCount()
    {
        AmountOfBoxes++;
    }

    void DestructionCount()
    {
        DestroyedBoxes++;
        Debug.Log("Destro: " + DestroyedBoxes);
    }
}
