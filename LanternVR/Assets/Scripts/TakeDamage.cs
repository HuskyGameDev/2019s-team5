using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public int health; // records the health of the object.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SubtractHealth ()
    {
        health--; // decrements the health of the object by one
        if (health <= 0)
        {
            Destroy(gameObject); // destroy the object and all associated objects if it loses all health
        }
    }
}
