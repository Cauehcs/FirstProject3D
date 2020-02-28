using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] bool[] animationStates;
    //0 - Idle
    //1 - Idle 2


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
           
    }

    private void Update()
    {
        ToIdle2();
    }
    
    float timeToIdle2;
    void ToIdle2()
    {
        if (animationStates[0]) timeToIdle2 += Time.deltaTime;
            else timeToIdle2 = 0;
       
        if (timeToIdle2 > 20) { animationStates[1] = true; timeToIdle2 = 0; }
        anim.SetBool("Idle2", animationStates[1]); animationStates[1] = false;
    }
}
