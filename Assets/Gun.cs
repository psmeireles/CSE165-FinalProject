using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject anchor;
    public GameObject correspondingGun;
    static Gun currentGun;


    // Start is called before the first frame update
    void Start()
    {
        correspondingGun.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightHand.transform.position) < 0.1) {
            bool rightHandGrab = OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger);
            if (rightHandGrab) {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                if(currentGun != null) {
                    currentGun.GetComponent<MeshRenderer>().enabled = true;
                    currentGun.correspondingGun.GetComponent<MeshRenderer>().enabled = false;
                }
                if(currentGun != this) {
                    currentGun = this;
                    this.correspondingGun.GetComponent<MeshRenderer>().enabled = true;
                }
                else {
                    currentGun = null;
                }
            }
        }

        if (Vector3.Distance(transform.position, leftHand.transform.position) < 0.1) {
            bool leftHandGrab = OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger);
            if (leftHandGrab) {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                if (currentGun != null) {
                    currentGun.GetComponent<MeshRenderer>().enabled = true;
                    currentGun.correspondingGun.GetComponent<MeshRenderer>().enabled = false;
                }
                if (currentGun != this) {
                    currentGun = this;
                    this.correspondingGun.GetComponent<MeshRenderer>().enabled = true;
                }
                else {
                    currentGun = null;
                }
            }
        }
    }
}
