using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAn : MonoBehaviour
{
    [SerializeField] Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void ActCube()
    {
        anim.SetBool("Active", true);
    }
}
