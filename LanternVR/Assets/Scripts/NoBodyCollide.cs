using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBodyCollide : MonoBehaviour {

    public GameObject[] collidersToIgnore;
    public string[] namesToIgnore;

	// Use this for initialization
	void Start () {
        foreach (GameObject col in collidersToIgnore)
        {
            if (col.GetComponent<Collider>() != null)
                Physics.IgnoreCollision(col.GetComponent<Collider>(), GetComponent<Collider>());
        }
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name + ", " + transform.name);
        foreach (string name in namesToIgnore)
        {
            if (collision.transform.name == name)
            {
                Debug.Log("Ignoring collision");
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            }
        }
    }
}
