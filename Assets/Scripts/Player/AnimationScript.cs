using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator; CharacterController characterController;
    [SerializeField] bool[] animationStates = new bool[2];
    //0 - Idle
    //1 - Idle 2
    //2 - Walking

    float speedGraduate, vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        ActionAnimationController();
    }
    
    //Method for control of Player's animation
    void ActionAnimationController()
    {
        Idle(); WalkingRun();
        Jump();
    }

    bool jump = false;
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jump = true;
            else jump = false;
        
        animator.SetBool("Jump", jump);
    }

    void WalkingRun()
    {
        speedGraduate = Mathf.Clamp(speedGraduate, 0f, 1f);
        vertical = Input.GetAxis("Vertical");

        if (vertical > 0) speedGraduate += Time.deltaTime / 2;
            else if (speedGraduate < 0 && vertical == 0) speedGraduate = 0;
                else speedGraduate -= Time.deltaTime * 8;

        if (vertical < 0) speedGraduate -= Time.deltaTime / 2;

        animator.SetFloat("Speed", speedGraduate);
    }

    void Idle()
    {
        if (speedGraduate <= 0) animationStates[0] = true;
        else animationStates[0] = false; ToIdle2();
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
