using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Vector3 destination;
    AudioSource portalSound;
    // Start is called before the first frame update
    void Start()
    {
        destination = this.transform.position - Vector3.right * 4;
        portalSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Toy") {
            portalSound.Play();
            other.gameObject.transform.position = destination;
        }
    }
}
