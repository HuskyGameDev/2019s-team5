//WeakPoint handles any target that can be impacted by the light of the player's lantern

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

    public Color[] col; //0 is regular, 1 is seen

    private Material targetMat;
    private bool isSeen = false;

    // Use this for initialization
    void Start () {
        targetMat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Seen(bool spotted) {
        isSeen = spotted;

        if (isSeen) {
            targetMat.color = col[1];
        } else {
            targetMat.color = col[0];
        }

    }



}
