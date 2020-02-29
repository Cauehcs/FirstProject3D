using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator; CharacterController characterController;
    [SerializeField] bool[] animationStates = new bool[3];
    //0 - Idle
    //1 - Idle 2
    //2 - Movement

    [SerializeField] float vertical, horizontal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical"); horizontal = Input.GetAxis("Horizontal");
        ActionAnimationController();
    }
    
    //Method for control of Player's animation
    void ActionAnimationController()
    {
        Jump();
        IdleWalkingRun();
    }

    bool jump = false;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jump = true;
            else jump = false;
        
        animator.SetBool("Jump", jump);
    }

    void IdleWalkingRun()
    {
        if (vertical == 0) animationStates[0] = true;
                     else animationStates[0] = false;


        ToIdle2(); if (vertical != 0 || horizontal != 0) animationStates[2] = true; else animationStates[2] = false;
        animator.SetBool("Movement", animationStates[2]);  animator.SetFloat("Vertical", vertical);
    }

    //method and variabe for switch of idle (Idle Variable)
    float timeToIdle2;
    void ToIdle2()
    {
        if (animationStates[0]) timeToIdle2 += Time.deltaTime;
            else timeToIdle2 = 0;
        
        Debug.Log(timeToIdle2);
        if (timeToIdle2 > 20) { animationStates[1] = true; timeToIdle2 = 0; }
        animator.SetBool("Idle2", animationStates[1]); animationStates[1] = false;
    }
}
