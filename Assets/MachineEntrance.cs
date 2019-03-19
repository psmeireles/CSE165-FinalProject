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
        GameObject obj = other.gameObject;

        //GameObject parentobj = obj.transform.parent.gameObject;
        //Debug.Log(parentobj);
        //Debug.Log(obj.transform);
        //parts.Add(parentobj.name);

        parts.Add(obj.name);

        updateListDisplay();
        //Destroy(other.gameObject.transform.parent.gameObject);

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
