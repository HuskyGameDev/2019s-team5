namespace VRTK {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AdvGunShoot : MonoBehaviour {

        public VRTK_InteractableObject linkedObject;

        public VRTK_ControllerEvents rightHand;
        public VRTK_ControllerEvents leftHand;

        public VRTK_ControllerEvents gunHand;

        public GameObject bullet;
        public Transform endOfBarrel;
        public float bulletSpeed = 1000f;
        public float bulletLife = 5f;

        public int ammoCount;
        public int ammoLimit; //The max amount of ammo allowed

        private void Start()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
            linkedObject.InteractableObjectGrabbed += OnInteractableObjectGrabbed;
            linkedObject.InteractableObjectUngrabbed += OnInteractableObjectUngrabbed;
        }

        protected virtual void OnEnable() {
            //gunHand = leftHand;

            

            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
            

            

        }

        protected virtual void OnInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            CheckHand(e.interactingObject.name);


        }

        protected virtual void OnInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            CheckHand("DROP");

        }

        //Return 0 for left, 1 for right, -1 for drop
        private int CheckHand(string aliasName)
        {
            int check = -2;

            
            if (aliasName == ("RightControllerScriptAlias")) //Right Hand
            {
                //Reset the button if it just swaps hands
                if (gunHand != null)
                    gunHand.ButtonOneReleased -= DoButtonOneReleased;

                gunHand = rightHand;

                //Double check if null
                if (gunHand != null)
                    gunHand.ButtonOneReleased += DoButtonOneReleased;

                check = 1;
                
            }
            else if (aliasName == ("LeftControllerScriptAlias")) //Left Hand
            {
                //Reset the button if it just swaps hands
                if (gunHand != null)
                    gunHand.ButtonOneReleased -= DoButtonOneReleased;

                gunHand = leftHand;

                //Double check if null
                if (gunHand != null)
                    gunHand.ButtonOneReleased += DoButtonOneReleased;

                check = 0;
            }
            else //neither hand
            {

                if (gunHand != null)
                    gunHand.ButtonOneReleased -= DoButtonOneReleased;

                gunHand = null;
                check = -1;
            }

            return check;
        }

        protected virtual void OnDisable() {
            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }


        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
            if (bullet != null && ammoCount > 0)
                Fire();
            
        }

        void Fire() {

            GameObject clonedProjectile = Instantiate(bullet, endOfBarrel.position, endOfBarrel.rotation);
            Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(clonedProjectile.transform.forward * bulletSpeed);
            }
            Destroy(clonedProjectile, bulletLife);

            ammoCount--;
            
        }

        void Awake() {
            ammoCount = ammoLimit;
        }

        // Update is called once per frame
        void Update() {
            
        }

        private void DoButtonOneReleased(object sender, ControllerInteractionEventArgs e)
        {
            ammoCount = ammoLimit;
        }
    }

}


