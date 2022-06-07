using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void BoxCount();
    public static event BoxCount boxC;
    int AmountOfBoxes;
    int DestroyedBoxes;
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
