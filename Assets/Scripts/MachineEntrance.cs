using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineEntrance : MonoBehaviour
{
    //public Text partsList;

    //private List<string> parts;
    MachineController machineController;
    
    // Start is called before the first frame update
    void Start()
    {
        //parts = new List<string>();
        machineController = GameObject.Find("ToyMachine").GetComponent<MachineController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        //parts.Add(obj.name.Replace("-Grababble(Clone)", ""));

        machineController.addToyPart(obj.name.Replace("-Grababble(Clone)", ""));
        machineController.updatePartsListDisplay();
        Destroy(other.gameObject);
    }

    //public List<string> getPartsList()
    //{
    //    return parts;
    //}

    //public void updateListDisplay()
    //{
    //    string partsText = "";

    //    foreach (string s in parts)
    //    {
    //        partsText += s + "\n";
    //    }

    //    partsList.text = "Current Parts:\n" + partsText;
    //}
}
