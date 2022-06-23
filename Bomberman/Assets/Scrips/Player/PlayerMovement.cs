using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace bomberman
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CharacterController controller;

        [SerializeField] private float speed = 5;
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private float turnSmoothVelocity;

        float horizontal;
        float vertical;
            
        void Update()
        {

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            if (direction.magnitude >= 0.1f)
            {
                float targerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targerAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                controller.Move(direction * speed * Time.deltaTime);
            }

        }

    }
}