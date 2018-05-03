﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : NetworkBehaviour{
    public GameObject cirvle;
    
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float Jumpspeed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start(){
        if (!isLocalPlayer)
        {
            return;
        }
        Cursor.lockState = CursorLockMode.Locked; 
        motor = GetComponent<PlayerMotor>();
    }

    void Update(){

        if (Input.GetKey(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None; 
        }
        
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookSensitivity;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        
        Vector3 cameraRotation = new Vector3 (xRot, 0f, 0f) * lookSensitivity;

        motor.RotateCamera(cameraRotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            motor.Jump(Jumpspeed);
        }
    }
}