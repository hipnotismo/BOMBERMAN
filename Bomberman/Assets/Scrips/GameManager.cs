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

        private void OnDisable()
        {
            DestroyWall.OnBoxSpawned -= AddCount;
            DestroyBomb.OnBoxDestroyed -= DestructionCount;
        }

        void Update()
        {
            if (AmountOfBoxes <= DestroyedBoxes)
            {
                EnableDoor?.Invoke();

            }
        }

        void AddCount()
        {
            Debug.Log(AmountOfBoxes);
            AmountOfBoxes++;

        }

        void DestructionCount()
        {
            Debug.Log(DestroyedBoxes);
            DestroyedBoxes++;
        }
    }
}