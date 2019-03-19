using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyColorizer : MonoBehaviour
{
    int currentPart;
    MeshRenderer[] parts;
    List<GameObject> currentCollisions = new List<GameObject>();
    float warningTime;
    bool warned;
    AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        parts = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        currentPart = 0;
        warned = false;
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(warned && Time.time - warningTime > 3) {
            warned = false;
            GameManager.warning.text = string.Empty;
        }
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
            hitSound.Play();
            parts[currentPart].material = collision.gameObject.GetComponent<MeshRenderer>().material;
            currentPart = (currentPart + 1) % parts.Length;
        }
        else if(collision.gameObject.tag == "Bullet" && !colorable && GameManager.warning.text == string.Empty) {
            GameManager.warning.text = "You can only colorize a toy if it's touching the conveyor belt!";
            warned = true;
            warningTime = Time.time;
        }
    }

    void OnCollisionExit(Collision col) {

        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
    }
}
