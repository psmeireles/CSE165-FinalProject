using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineEntrance : MonoBehaviour
{
    //public Text partsList;

    //private List<string> parts;
    MachineController machineController;
    AudioSource machineSound;
    // Start is called before the first frame update
    void Start()
    {
        machineController = GameObject.Find("ToyMachine").GetComponent<MachineController>();
        machineSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        
        if(obj.tag == "ToyPart")
        {
            machineSound.Play();
            machineController.addToyPart(obj.name.Replace("-Grabbable(Clone)", ""));
            machineController.updatePartsListDisplay();
            Destroy(other.gameObject);
        }
    }
}
