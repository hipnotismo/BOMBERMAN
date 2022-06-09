using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDoor : MonoBehaviour
{
    private void OnEnable()
    {
      //  GameManager.EnableDoor += Enable;
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter /*OnControllerColliderHit*/(Collision collision)
    {
        //if (this.ActiveSelf == true)
        //{
        //    Debug.Log("Hell yeah");
        //}
        //else
        //{
        //    Debug.Log("Fuck");

        //}
        Debug.Log("Fuck");
    }

}
