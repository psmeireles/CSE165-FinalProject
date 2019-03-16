using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyColorizer : MonoBehaviour
{
    int currentPart;
    MeshRenderer[] parts;
    List<GameObject> currentCollisions = new List<GameObject>();

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

        // Add the GameObject collided with to the list.
        currentCollisions.Add(collision.gameObject);

        bool colorable = false;
        foreach (GameObject gObject in currentCollisions) {
            if(gObject.tag == "Conveyor") {
                colorable = true;
            }
        }

        if (colorable && collision.gameObject.tag == "Bullet") {
            parts[currentPart].material = collision.gameObject.GetComponent<MeshRenderer>().material;
            currentPart = (currentPart + 1) % parts.Length;
        }
    }

    void OnCollisionExit(Collision col) {

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
    }
}
