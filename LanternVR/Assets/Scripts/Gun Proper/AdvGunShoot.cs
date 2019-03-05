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

        private int ammoCount;
        public int ammoLimit; //The max amount of ammo allowed

        public bool checkHand;

        protected virtual void OnEnable() {
            //gunHand = leftHand;

            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }

            if(transform.parent != null && transform.parent.name.CompareTo("controller_right") == 1)
            {
                gunHand = rightHand;
            }
            else if (transform.parent != null && transform.parent.name.CompareTo("controller_left") == 1)
            {
                gunHand = leftHand;
            }

            UnityEngine.Debug.Log("111");
            checkHand = true;

            if (gunHand != null)
            {
                gunHand.ButtonOneReleased += DoButtonOneReleased;
            }

        }

        protected virtual void OnDisable() {
            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }

            if (gunHand != null)
            {
                gunHand.ButtonOneReleased -= DoButtonOneReleased;
                gunHand = null;
            }

            checkHand = false;

        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
           
            Fire();
            
        }

        void Fire() {
            if (bullet != null && ammoCount > 0)
            {

                GameObject clonedProjectile = Instantiate(bullet, endOfBarrel.position, endOfBarrel.rotation);
                Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.AddForce(clonedProjectile.transform.forward * bulletSpeed);
                }
                Destroy(clonedProjectile, bulletLife);

                ammoCount--;
            }
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


