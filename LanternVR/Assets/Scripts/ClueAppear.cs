using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueAppear : MonoBehaviour {

    public GameObject clue;
    public GameObject highlight;
    public bool hasClue = false;
    public GameObject winChecker;

	// Use this for initialization
	void Start () {
        clue.SetActive(false);
        highlight.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MainCamera" && hasClue)
        {
            clue.SetActive(true);
            highlight.SetActive(false);
            winChecker.SendMessage("ClueFound");
            gameObject.GetComponent<ClueAppear>().enabled = false;
        }
    }
}
