using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] CharacterController controller;

    //Vector2 movement;

    [SerializeField] private float speed =5;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothVelocity;

    float horizontal;
    float vertical;
    void Update()
    {
        //movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //  Vector3 move = new Vector3(movement.x, 0f, movement.y); /*transform.right * movement.x + transform.forward * movement.y;*/

        //        controller.Move(move * speed * Time.deltaTime);
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (/*move*/direction.magnitude >= 0.1f)
        {
            float targerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targerAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }

    }

}

