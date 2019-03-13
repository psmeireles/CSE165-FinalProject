using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyColorizer : MonoBehaviour
{
    int currentPart;
    MeshRenderer[] parts;

    // Start is called before the first frame update
    void Start()
    {
        parts = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        currentPart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Bullet") {
            parts[currentPart].material = collision.gameObject.GetComponent<MeshRenderer>().material;
            currentPart = (currentPart + 1) % parts.Length;
        }
    }
}
