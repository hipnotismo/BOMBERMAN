using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] CharacterController controller;

    Vector2 movement;

    [SerializeField] private float speed;

public static Action<PlayerMovement> onPlayerSpawn;

    void Update()
    {   
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        controller.Move(move * speed * Time.deltaTime);

    }

}

