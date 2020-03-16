using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGun : MonoBehaviour
{
    public Animator animCursor;
    public GameObject takedTarget;

    private void Awake(){

    }

    private void Update(){
        AnimCursor(); SearchTarget();
    }

    private void FixedUpdate(){
        actionGun();
    }

    void actionGun(){
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            if (hit.collider.gameObject.tag == "boxTarget" && Input.GetButtonDown("Fire1")) {
                takedTarget = hit.collider.gameObject;
            }

            if (takedTarget) {
                takedTarget.GetComponent<ActiveScript>().ActivateObject();
                takedTarget = null;
            }
            
        }
    }

    void SearchTarget(){
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = Physics.Raycast(ray.origin, ray.direction, 5f);
            if (hit) PlayerFirstBehaviour.targetOn = true;
                else PlayerFirstBehaviour.targetOn = false;
    }

    void AnimCursor(){
        animCursor.SetBool("On", PlayerFirstBehaviour.targetOn);
    }

}
