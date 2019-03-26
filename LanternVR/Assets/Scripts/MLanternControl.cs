//MLanternControl controls the strength of the light and
//the size of the associated trigger sphere using the distance
//between a point in space and the lantern iteself.

namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MLanternControl : MonoBehaviour
    {

        private VRTK_InteractableObject linkedObject;

        [SerializeField]
        private Light candleLight; //Control the radius of this 
        [SerializeField]
        private SphereCollider candleCollider; //control the radius of this too

        [SerializeField]
        private float[] minMaxCandleLight;//0 is min, 1 is max.
        [SerializeField]
        private float[] minMaxCandleTrigger; //0 is min, 1 is max.

        // Use this for initialization
        private void Start()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
            linkedObject.InteractableObjectGrabbed += OnInteractableObjectGrabbed;
            linkedObject.InteractableObjectUngrabbed += OnInteractableObjectUngrabbed;
            candleCollider.radius = minMaxCandleTrigger[0];
            candleLight.range = minMaxCandleLight[0];
        }

        protected virtual void OnInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            candleCollider.radius = minMaxCandleTrigger[1];
            candleLight.range = minMaxCandleLight[1];
        }

        protected virtual void OnInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            candleCollider.radius = minMaxCandleTrigger[0];
            candleLight.range = minMaxCandleLight[0];

        }

    }
}



