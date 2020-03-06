using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFirstBehaviour : MonoBehaviour
{

    public bool lockMouse = true, jumping;
    public static bool targetOn;
    public float sensibility, speed, gravity, jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;


    private float mouseX = 0.0f, mouseY = 0.0f;

    GameObject lookAt; [SerializeField] BoxCollider colliderTarget;
    [SerializeField] GameObject[] cursorBroken;
    CharacterController characterController; Animator animGun;
    private void Awake()
    {
        characterController = GameObject.Find("Player Body").GetComponent<CharacterController>();
        animGun = GameObject.Find("weaponLP").GetComponent<Animator>();
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

    void ActionsPlayer()
    {
        if (targetOn)
        {
            for (int i = 0; i < cursorBroken.Length; i++)
            {
                cursorBroken[i].GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            for (int i = 0; i < cursorBroken.Length; i++)
            {
                cursorBroken[i].GetComponent<Image>().color = Color.black;
            }
        }
    }

    float plus;
    void PlayeMovement()
    {
      
        Vector3 lookAtValue = gameObject.transform.position - lookAt.transform.position;

        ActionsPlayer();

        Vector3 verticalMovement = Input.GetAxis("Vertical") * speed * new Vector3(lookAtValue.x, 0f, lookAtValue.z);
        Vector3 horizontalMovement = Input.GetAxis("Horizontal") * transform.right * (speed * 1.5f);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0 ||
                    Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) 
                        { plus = 1; animGun.SetBool("Run", false); } 

            else { plus = 1.8f; animGun.SetBool("Run", true); }
        }
        else { plus = 1; animGun.SetBool("Run", false); }

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0) { horizontalMovement *= 2.4f; }

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = (verticalMovement * -1 + horizontalMovement) * plus;
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
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