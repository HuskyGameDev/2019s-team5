using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeakPointRandomizer : MonoBehaviour {

    public GameObject[] weakPoints;
    System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {
		
	}


    private void Awake()
    {
        randomWeaknessFunction();
    }

    public void randomWeaknessFunction()
    {

        for(int i = 0; i < weakPoints.Length; i++)          // set all locations to false 
        {
            weakPoints[i].GetComponent<WeakPoint>().enabled = false;
            weakPoints[i].GetComponent<Collider>().enabled = false;
        }

        int numberOfWeakpoints = rnd.Next(1, 4);            //generate random number for the weakpoints
        GetComponent<TakeDamage>().health = numberOfWeakpoints;
        
        for(int i = 1; i <= numberOfWeakpoints; i++)
        {
           

            int weaknessPosition = rnd.Next(0, weakPoints.Length);          // generate random number for the index that will be turned on 

            if(weakPoints[weaknessPosition].GetComponent<WeakPoint>().enabled == false)
            {
                weakPoints[weaknessPosition].GetComponent<WeakPoint>().enabled = true;   // activate the weakness at index 
                weakPoints[weaknessPosition].GetComponent<Collider>().enabled = true;

            }
            else
            {
                i--;                                            // decrement i if the index has already been turned on and try again
            }
        }


        
    }


	// Update is called once per frame
	void Update () {
		
	}
}
