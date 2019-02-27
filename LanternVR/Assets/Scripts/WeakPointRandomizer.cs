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
	
    public void randomWeaknessFunction()
    {

        for(int i = 0; i < weakPoints.Length; i++)
        {
            weakPoints[i].SetActive(false);
        }

        int numberOfWeakpoints = rnd.Next(1, 3);        //generate random number for the weakpoints
        
        for(int i = 1; i <= numberOfWeakpoints; i++)
        {
            int weaknessPosition = rnd.Next(1, 9);
            weakPoints[weaknessPosition].SetActive(true);
        }


        
    }


	// Update is called once per frame
	void Update () {
		
	}
}
