using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusRHandGrab : MonoBehaviour
{
    public GameObject CollidingObject;
    public GameObject objectInHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        if (rTrigger > 0.2 && CollidingObject) {
            GrabObject();
        }
        if (rTrigger < 0.2 && objectInHand) {
            ReleaseObject();
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Rigidbody>()) {
            CollidingObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other) {
        CollidingObject = null;
    }

    public void GrabObject() {
        objectInHand = CollidingObject;
        objectInHand.transform.SetParent(this.transform);
        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ReleaseObject() {
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }
}
