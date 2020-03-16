using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOff : MonoBehaviour
{
    public string nameScript;
    private void Start() {
        if (nameScript == "GuardRail_01_snaps002") GetComponent<ScriptBarMetal>().enabled = true;
    }
}
