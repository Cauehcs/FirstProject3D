using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirstBehaviour : MonoBehaviour
{

    public bool lockMouse = true;
    public float sensibility, speed, gravity, jumpForce;

    private float mouseX = 0.0f, mouseY = 0.0f;

    GameObject lookAt;
    Rigidbody myRG;

    private void Awake()
    {
        myRG = GameObject.Find("Player Body").GetComponent<Rigidbody>();
        lookAt = GameObject.Find("LookAt");
    }

    private void Start()
    {
        MouseMovementSettings();
    }

    private void Update()
    {
        MouseMovement(); PlayeMovement();
    }

    float plus;
    void PlayeMovement()
    {
        Vector3 lookAtValue = gameObject.transform.position - lookAt.transform.position;

        Vector3 verticalMovement = Input.GetAxis("Vertical") * speed * new Vector3(lookAtValue.x, 0f, lookAtValue.z);
        Vector3 horizontalMovement = Input.GetAxis("Horizontal") * transform.right * (speed * 1.5f);

        if (Input.GetKey(KeyCode.LeftShift)) plus = 1.8f; else plus = 1;
        myRG.velocity = horizontalMovement + ((verticalMovement * -1) / 2.4f) * plus;
    }

    void MouseMovement()
    {
        mouseX += Input.GetAxis("Mouse X") * sensibility; 
        mouseY -= Input.GetAxis("Mouse Y") * sensibility;
        mouseY = Mathf.Clamp(mouseY, -60, 65);
        transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    void MouseMovementSettings()
    {
        if (!lockMouse)
        {
            return;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}