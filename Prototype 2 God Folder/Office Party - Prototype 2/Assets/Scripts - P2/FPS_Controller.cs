﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    public float speed = 2f;
    public float sensitivity = 2f;
    CharacterController player;
    public GameObject eyes;
    float moveFB;
    float moveLR;
    float rotX;
    float rotY;
    void Start() {
        player = GetComponent<CharacterController>();
    }
    void Update() {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);
        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0, rotX, 0);
        eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
    }
}
