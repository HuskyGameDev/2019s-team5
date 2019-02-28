namespace VRTK {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AdvGunShoot : MonoBehaviour {

        public VRTK_InteractableObject linkedObject;

        public GameObject bullet;
        public Transform endOfBarrel;
        public float bulletSpeed = 1000f;
        public float bulletLife = 5f;

        public int ammoCount;

        protected virtual void OnEnable() {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
        }

        protected virtual void OnDisable() {
            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e) {
           
            Fire();
            
        }

        void Fire() {

        }

        void Awake() {

        }

        // Update is called once per frame
        void Update() {
            if () {

            }
        }
    }

}


