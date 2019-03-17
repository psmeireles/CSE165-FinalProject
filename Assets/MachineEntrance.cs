using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineEntrance : MonoBehaviour
{
    public Text partsList;

    private List<string> parts;
    private 
    // Start is called before the first frame update
    void Start()
    {
        parts = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        parts.Add(other.gameObject.transform.parent.gameObject.name);

        updateListDisplay();
        Destroy(other.gameObject);
    }

    public List<string> getPartsList()
    {
        return parts;
    }

    public void updateListDisplay()
    {
        string partsText = "";

        foreach (string s in parts)
        {
            partsText += s + "\n";
        }

        partsList.text = "Current Parts:\n" + partsText;
    }
}
