//MLanternControl controls the strength of the light and
//the size of the associated trigger sphere using the distance
//between a point in space and the lantern iteself.

namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class NewLanternControl : MonoBehaviour
    {

        private VRTK_InteractableObject linkedObject;

        [SerializeField]
        private SphereCollider lightCollider; //Control the radius of this 
        [SerializeField]
        private Light areaLight; //control the radius of this too
        [SerializeField]
        private Light spotLight; //control the radius of this too

        [SerializeField]
        private float[] minMaxTrigger;//0 is min, 1 is max.
        [SerializeField]
        private float[] minMaxAreaLight; //0 is min, 1 is max.
        [SerializeField]
        private float[] minMaxSpotLight; //0 is min, 1 is max.

        // Use this for initialization
        private void Start()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
            linkedObject.InteractableObjectGrabbed += OnInteractableObjectGrabbed;
            linkedObject.InteractableObjectUngrabbed += OnInteractableObjectUngrabbed;
            areaLight.range = minMaxAreaLight[0];
            spotLight.range = minMaxSpotLight[0];
            lightCollider.radius = minMaxTrigger[0];
        }

        protected virtual void OnInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            areaLight.range = minMaxAreaLight[1];
            spotLight.range = minMaxSpotLight[1];
            lightCollider.radius = minMaxTrigger[1];
        }

        protected virtual void OnInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            areaLight.range = minMaxAreaLight[0];
            spotLight.range = minMaxSpotLight[0];
            lightCollider.radius = minMaxTrigger[0];

        }

    }
}



