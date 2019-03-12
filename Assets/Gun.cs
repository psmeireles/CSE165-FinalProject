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
        correspondingGun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightHand.transform.position) < 0.1) {
            bool rightHandGrab = OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger);
            if (rightHandGrab) {
                this.gameObject.SetActive(false);
                if(currentGun != null) {
                    currentGun.gameObject.SetActive(true);
                    currentGun.correspondingGun.SetActive(false);
                }
                currentGun = this;
                this.correspondingGun.SetActive(true);
            }
        }

        if (Vector3.Distance(transform.position, leftHand.transform.position) < 0.1) {
            bool leftHandGrab = OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger);
            if (leftHandGrab) {
                this.gameObject.SetActive(false);
                if (currentGun != null) {
                    currentGun.gameObject.SetActive(true);
                    currentGun.correspondingGun.SetActive(false);
                }
                currentGun = this;
                this.correspondingGun.SetActive(true);
            }
        }
    }
}
