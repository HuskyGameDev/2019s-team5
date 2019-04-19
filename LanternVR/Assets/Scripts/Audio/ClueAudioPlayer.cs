using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueAudioPlayer : MonoBehaviour {

    AudioSource player;

	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
	}
	
	private void PlayClueSound(Transform tran)
    {
        GetComponent<Transform>().position = tran.position;
        player.Play();
    }
}
