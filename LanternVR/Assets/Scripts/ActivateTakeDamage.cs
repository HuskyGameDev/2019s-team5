using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTakeDamage : MonoBehaviour {

    private bool triggered = false; // when false, allows object to call TakeDamage

    public TakeDamage parentNode; //The parent node that holds the target that will be hit.


    /*void OnTriggerEnter(Collider col) {
        if (!triggered && col.transform.tag == "SnapBullet") {
            parentNode.SubtractHealth(); // call TakeDamage on an object collision
            triggered = true;            //Object can't take anymore damage
            gameObject.SetActive(false);
            Debug.Log(col.transform.name);
        }
    }*/

    private void OnCollisionEnter(Collision col)
    {
        if (!triggered && col.transform.tag == "SnapBullet")
        {
            parentNode.SubtractHealth(); // call TakeDamage on an object collision
            triggered = true;            //Object can't take anymore damage
            gameObject.GetComponent<WeakPoint>().enabled = false;   // activate the weakness at index 
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(col.gameObject);
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
