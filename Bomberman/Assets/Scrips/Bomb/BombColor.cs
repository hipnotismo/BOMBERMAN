using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bomberman
{
    public class BombColor : MonoBehaviour
    {
        private Material material;

        void Awake()
        {
            DestroyBomb.ColorToRed += ChangeToRed;
        }
        void Start()
        {
            material = gameObject.GetComponent<Material>();
        }

        void ChangeToRed()
        {
            material.color = Color.red;
        }
    }
}