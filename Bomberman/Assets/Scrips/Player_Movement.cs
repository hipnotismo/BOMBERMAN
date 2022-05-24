using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    Vector2 movement;

    [SerializeField] private float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movement.x + transform.forward * movement.y;

        controller.Move(move * speed * Time.deltaTime);
    
    }
}
