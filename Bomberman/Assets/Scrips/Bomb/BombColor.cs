using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bomberman
{
    public class BombColor : MonoBehaviour
    {
        private Renderer render;

        void Awake()
        {
            DestroyBomb.ColorToRed += ChangeToRed;
        }

        private void OnDestroy()
        {
            DestroyBomb.ColorToRed -= ChangeToRed;
        }
        void Start()
        {
            render = gameObject.GetComponent<Renderer>();
        }

        void ChangeToRed()
        {
            render.material.color = Color.red;
        }
    }
}