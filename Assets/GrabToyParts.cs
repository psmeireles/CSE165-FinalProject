using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabToyParts : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject grababbleObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightHand.transform.position) < 0.4) {
            bool rightHandGrab = OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger);
            if (rightHandGrab) {
                GameObject.Instantiate(grababbleObj);
            }
        }

        if (Vector3.Distance(transform.position, leftHand.transform.position) < 0.4) {
            bool leftHandGrab = OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger);
            if (leftHandGrab) {
                GameObject.Instantiate(grababbleObj);
            }
        }
    }
}
