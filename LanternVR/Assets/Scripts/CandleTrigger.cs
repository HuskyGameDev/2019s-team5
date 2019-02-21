using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTrigger : MonoBehaviour {

    private List<WeakPoint> weakList; //List of weak points to keep watch on
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        weakList = new List<WeakPoint>();
	}

    void Update() {
        if(weakList.Count != 0) {
            foreach (WeakPoint wp in weakList) {
                if(wp != null) {
                    Physics.Raycast(transform.position, wp.transform.position - transform.position, out hit);

                    if (hit.transform == wp.transform) {
                        wp.Seen(true);
                    }
                    else {
                        wp.Seen(false);
                    }
                }

            }
        }  
    }
	
	private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "CandleTriggered") {
            WeakPoint wp = other.GetComponent<WeakPoint>();
            wp.Seen(true);
            weakList.Add(wp);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "CandleTriggered") {
            WeakPoint wp = other.GetComponent<WeakPoint>();
            wp.Seen(false);
            weakList.Remove(wp);
        }
    }

}
