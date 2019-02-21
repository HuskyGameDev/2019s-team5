using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTakeDamage : MonoBehaviour {

    private bool triggered = false; // when false, allows object to call TakeDamage

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (triggered)
        {
            GetComponent<TakeDamage>().SubtractHealth(); // call TakeDamage on an object collision
        }
        else
        {
            triggered = true; // only allow call to TakeDamage once
        }
    }
}
