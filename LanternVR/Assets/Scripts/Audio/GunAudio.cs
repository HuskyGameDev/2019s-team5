using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAudio : MonoBehaviour {

    AudioSource sound;
    public AudioClip[] gunshots;
    public AudioClip[] pickup;
    public AudioClip[] putdown;
    public AudioClip[] eject;
    public AudioClip[] loadAmmo;
    public AudioClip[] close;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
	}

    private void PlayAudio(string name)
    {
        
        switch (name)
        {
            case "gunshot":
                if (putdown.Length > 0)
                {
                    sound.clip = gunshots[(int)Random.Range(0f, gunshots.Length - .01f)];
                    sound.Play();
                }
                break;
            case "pickup":
                if (pickup.Length > 0)
                {
                    sound.clip = pickup[(int)Random.Range(0f, pickup.Length - .01f)];
                    sound.Play();
                }
                break;
            case "putdown":
                if (putdown.Length > 0)
                {
                    sound.clip = putdown[(int)Random.Range(0f, putdown.Length - .01f)];
                    sound.Play();
                }
                break;
            case "eject":
                if (eject.Length > 0)
                {
                    sound.clip = eject[(int)Random.Range(0f, eject.Length - .01f)];
                    sound.Play();
                }
                break;
            case "loadAmmo":
                if (loadAmmo.Length > 0)
                {
                    sound.clip = loadAmmo[(int)Random.Range(0f, loadAmmo.Length - .01f)];
                    sound.Play();
                }
                break;
            case "close":
                if (close.Length > 0)
                {
                    sound.clip = close[(int)Random.Range(0f, close.Length - .01f)];
                    sound.Play();
                }
                break;
        }
    }
}
