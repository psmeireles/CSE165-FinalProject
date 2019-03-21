using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject leftController;

    float timeStartedWalking;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        float lTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        if (lTrigger > 0) {
            Vector3 direction = leftController.transform.forward;
            direction.y = 0;
            this.transform.Translate(direction * lTrigger * speed, Space.World);
            
            //Head Bobbing
            //Vector3 pos = this.transform.position;
            //pos.y = Mathf.Sin((Time.time - timeStartedWalking)*5*lTrigger) * 0.1f;
            //this.transform.position = pos;
        }
    }
}
