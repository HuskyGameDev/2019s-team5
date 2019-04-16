namespace VRTK
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CluePickUp : MonoBehaviour
    {

        private VRTK_InteractableObject linkedObject;
        public GameObject cluePosition;

        // Use this for initialization
        void Start()
        {
            //linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
            linkedObject = GetComponent<VRTK_InteractableObject>();
            linkedObject.InteractableObjectGrabbed += OnInteractableObjectGrabbed;
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected virtual void OnInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            cluePosition.GetComponent<ClueAppear>().hasClue = true;
            Destroy(gameObject);


        }
    }
}
