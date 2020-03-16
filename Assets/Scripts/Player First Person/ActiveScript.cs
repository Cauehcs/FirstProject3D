using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScript : MonoBehaviour
{
    public GameObject GOForActivate;
    public bool canActivate;

    private void Start() {
        canActivate = false;
    }

    public void ActivateObject() {
        canActivate = true;
    }

    private void Update() {
        if (canActivate) GOForActivate.GetComponent<ScriptOff>().enabled = true;
    }
}
