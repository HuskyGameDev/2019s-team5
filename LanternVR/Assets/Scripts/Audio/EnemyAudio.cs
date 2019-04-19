using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {

    AudioSource sound;
    public AudioClip[] attack;
    public AudioClip[] death;
    public AudioClip[] trigger;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void PlayAudio(string name)
    {

        switch (name)
        {
            case "attack":
                if (attack.Length > 0)
                {
                    sound.clip = attack[(int)Random.Range(0f, attack.Length - .01f)];
                    sound.Play();
                }
                break;
            case "pickup":
                if (death.Length > 0)
                {
                    sound.clip = death[(int)Random.Range(0f, death.Length - .01f)];
                    sound.Play();
                }
                break;
            case "putdown":
                if (trigger.Length > 0)
                {
                    sound.clip = trigger[(int)Random.Range(0f, trigger.Length - .01f)];
                    sound.Play();
                }
                break;
        }
    }
}
