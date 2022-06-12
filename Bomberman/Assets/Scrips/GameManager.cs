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
     //   Debug.Log("Destroy "+DestroyedBoxes);

     //   Debug.Log("Created box: " + DestroyedBoxes);

        if (AmountOfBoxes <= DestroyedBoxes)
        {
            EnableDoor?.Invoke();
            Debug.Log("Destoy and create are equal");
        }
    }

    void AddCount()
    {
        AmountOfBoxes++;
        Debug.Log("Created box: " + AmountOfBoxes);

    }

    void DestructionCount()
    {
        DestroyedBoxes++;
        Debug.Log("Destroy box: " + DestroyedBoxes);
    }
}
