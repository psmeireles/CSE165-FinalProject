using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject leftController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float lTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (lTrigger > 0.2) {
            Vector3 direction = leftController.transform.forward;
            direction.y = 0;
            this.transform.Translate(direction * 0.2f);
        }
    }
}
