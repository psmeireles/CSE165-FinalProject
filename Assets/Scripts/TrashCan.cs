using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    AudioSource trashSound;
    // Start is called before the first frame update
    void Start()
    {
        trashSound = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Contains("Toy")) {
            trashSound.Play();
            Destroy(other.gameObject);
        }
    }
}
