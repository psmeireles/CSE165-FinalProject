using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject bullet;
    public GameObject correspondingGun;
    public AudioClip reloadSound;
    AudioSource gunSound;
    float projSpeed;
    static Gun currentGun;
    public Material whiteMaterial;
    Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        correspondingGun.GetComponent<MeshRenderer>().enabled = false;
        projSpeed = 3000;
        gunSound = GetComponent<AudioSource>();
        originalMaterial = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, rightHand.transform.position) < 0.1) {
            bool rightHandGrab = OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger);
            if (rightHandGrab) {
                this.gameObject.GetComponent<MeshRenderer>().material = whiteMaterial;
                if(currentGun != null) {
                    currentGun.GetComponent<MeshRenderer>().material = currentGun.originalMaterial;
                    currentGun.correspondingGun.GetComponent<MeshRenderer>().enabled = false;
                }
                if(currentGun != this) {
                    currentGun = this;
                    this.correspondingGun.GetComponent<MeshRenderer>().enabled = true;
                    AudioSource.PlayClipAtPoint(reloadSound, currentGun.correspondingGun.transform.position);
                }
                else {
                    currentGun = null;
                }
            }
        }

        if (Vector3.Distance(transform.position, leftHand.transform.position) < 0.1) {
            bool leftHandGrab = OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger);
            if (leftHandGrab) {
                this.gameObject.GetComponent<MeshRenderer>().material = whiteMaterial;
                if (currentGun != null) {
                    currentGun.GetComponent<MeshRenderer>().material = currentGun.originalMaterial;
                    currentGun.correspondingGun.GetComponent<MeshRenderer>().enabled = false;
                }
                if (currentGun != this) {
                    currentGun = this;
                    this.correspondingGun.GetComponent<MeshRenderer>().enabled = true;
                    AudioSource.PlayClipAtPoint(reloadSound, currentGun.correspondingGun.transform.position);
                }
                else {
                    currentGun = null;
                }
            }
        }

        if(currentGun == this) {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)){
                AudioSource.PlayClipAtPoint(gunSound.clip, currentGun.correspondingGun.transform.position);
                GameObject projectile = GameObject.Instantiate(bullet, this.correspondingGun.transform.position, this.transform.rotation);
                projectile.GetComponent<Rigidbody>().AddForce(this.correspondingGun.transform.forward * projSpeed);
            }
        }
    }
}
