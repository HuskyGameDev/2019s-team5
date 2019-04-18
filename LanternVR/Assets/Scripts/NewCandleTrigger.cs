using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCandleTrigger : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CandleTriggered")
        {
            WeakPoint wp = other.GetComponent<WeakPoint>();
            wp.Seen(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CandleTriggered")
        {
            WeakPoint wp = other.GetComponent<WeakPoint>();
            wp.Seen(false);
        }
    }
}
