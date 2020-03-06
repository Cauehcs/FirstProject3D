using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGun : MonoBehaviour
{
    public Animator animCursor;

    private void Awake()
    {

    }

    private void Update()
    {
        AnimCursor(); SearchTarget();
    }

    void SearchTarget()
    {
      
    }

    void AnimCursor()
    {
        animCursor.SetBool("On", PlayerFirstBehaviour.targetOn);
    }

    private void OnTriggerStay(Collider other)
    {

    }
}
