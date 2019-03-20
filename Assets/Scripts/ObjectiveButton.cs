using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveButton : MonoBehaviour
{
    public Transform rightHand;
    AudioSource buttonSound;
    public static string tableRequirements;
    float warningTime;
    bool warned;
    // Start is called before the first frame update
    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (warned && Time.time - warningTime > 5) {
            warned = false;
            GameManager.warning.text = string.Empty;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(Vector3.Distance(this.transform.position, rightHand.position) < 0.1) {
            buttonSound.Play();

            GameManager.warning.text = tableRequirements;
            warned = true;
            warningTime = Time.time;
        }
    }
}
