using UnityEngine;
using System;

namespace bomberman
{
    public class GameManager : MonoBehaviour
    {

        private int AmountOfBoxes;
        private int DestroyedBoxes;

        public static Action EnableDoor;

        private void OnEnable()
        {
            DestroyWall.OnBoxSpawned += AddCount;
            DestroyBomb.OnBoxDestroyed += DestructionCount;
        }

        void Update()
        {
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
}