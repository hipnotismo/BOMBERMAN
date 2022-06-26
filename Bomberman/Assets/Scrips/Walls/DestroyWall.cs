using System;
using UnityEngine;

namespace bomberman
{
    public class DestroyWall : MonoBehaviour, IDamageable
    {

        public static Action OnBoxSpawned;

        private void Start()
        {
            OnBoxSpawned?.Invoke();
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }
    }
}