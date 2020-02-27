using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    CharacterController characterController;
    Transform mainCamera;

    public float speed, jumpSpeed, gravity;
    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {

    }






























    //bool lockMouse;
    //public float mouseX, mouseY,sensibilityMouse;
    //void Start()
    //{
    //    characterController = GetComponent<CharacterController>();
    //    mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();

    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //void Update()
    //{
    //    Movement();
    //}

    //void Movement()
    //{
    //    if (Input.GetKeyDown(KeyCode.F)) lockMouse = !lockMouse;
    //    if (lockMouse) MouseMovement();
    //}

    //void MouseMovement()
    //{
    //    Vector3 rotationCamera = mainCamera.eulerAngles;

    //    mouseX += Input.GetAxis("Mouse X") * sensibilityMouse;
    //    mouseY += Input.GetAxis("Mouse Y") * sensibilityMouse;

    //    mainCamera.eulerAngles = new Vector3(mouseY * -1, mouseX, 0f);
    //    if (rotationCamera.x < -40) print("a");
    //}
}
