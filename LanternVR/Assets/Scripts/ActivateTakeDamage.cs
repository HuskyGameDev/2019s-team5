using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTakeDamage : MonoBehaviour {

    private bool triggered = false; // when false, allows object to call TakeDamage

    public TakeDamage parentNode; //The parent node that holds the target that will be hit.


    void OnTriggerEnter(Collider col) {
        if (!triggered && col.transform.name == "bat") {
            parentNode.SubtractHealth(); // call TakeDamage on an object collision
            triggered = true;            //Object can't take anymore damage
        }
    }

    /*
    void OnCollisionEnter(Collision col)
    {
        if (!triggered)
        {
            parentNode.SubtractHealth(); // call TakeDamage on an object collision
            triggered = true;            //Object can't take anymore damage
        }
    }
    */
}
