//MLanternControl controls the strength of the light and
//the size of the associated trigger sphere using the distance
//between a point in space and the lantern iteself.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLanternControl : MonoBehaviour {

    [SerializeField]
    private Light candleLight; //Control the radius of this 
    [SerializeField]
    private SphereCollider candleCollider; //control the radius of this too

    [SerializeField]
    private float[] minMaxCandleLight;//0 is min, 1 is max.
    [SerializeField]
    private float[] minMaxCandleTrigger; //0 is min, 1 is max.
    [SerializeField]
    private float maxEffectDist;//How far out it can be held and be affective
    [SerializeField]
    private Vector3 fixedPoint; //The fixed position to compare the current position to

    float triggerTemp, candleTemp, ratio;

	// Use this for initialization
	void Start () {
        candleCollider.radius = minMaxCandleTrigger[0];
        candleLight.range = minMaxCandleLight[0];

        //replace this line with the player's location
        fixedPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        ratio = Vector3.Magnitude(transform.position - fixedPoint) / maxEffectDist;

        triggerTemp = .5f * ratio * minMaxCandleTrigger[1];
        candleTemp = .5f * ratio * minMaxCandleLight[1];

        triggerTemp = Mathf.Clamp(triggerTemp, minMaxCandleTrigger[0], minMaxCandleTrigger[1]);
        candleTemp = Mathf.Clamp(candleTemp, minMaxCandleLight[0], minMaxCandleLight[1]);

        candleCollider.radius = triggerTemp;
        candleLight.range = candleTemp;

    }



}
