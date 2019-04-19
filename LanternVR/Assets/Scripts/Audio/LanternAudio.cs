namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LanternAudio : MonoBehaviour
    {

        AudioSource sound;
        public AudioClip[] lanternSqueak;
        public AudioClip[] pickup;
        public AudioClip[] putdown;

        public VRTK_InteractableObject linkedObject;
        private bool held;
        private float squeakTime;
        

        // Use this for initialization
        void Start()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
            linkedObject.InteractableObjectGrabbed += OnInteractableObjectGrabbed;
            linkedObject.InteractableObjectUngrabbed += OnInteractableObjectUngrabbed;

            held = false;
            sound = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (held)
                if (squeakTime <= Time.time)
                {
                    squeakTime = Random.Range(3f, 10f) + Time.time;
                    PlayAudio("squeak");
                }
        }

        private void PlayAudio(string name)
        {

            switch (name)
            {
                case "squeak":
                    if (putdown.Length > 0)
                    {
                        sound.clip = lanternSqueak[(int)Random.Range(0f, lanternSqueak.Length - .01f)];
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
            }
        }

        
        protected virtual void OnInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            PlayAudio("pickup");
            held = true;

        }

        protected virtual void OnInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            PlayAudio("putdown");
            held = false;
        }
    }
}
