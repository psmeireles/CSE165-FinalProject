using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineController : MonoBehaviour
{
    public GameObject toy;
    public Vector3 toySpawnLocation;
    public Text partsList;
    public int delayBetweenCopiesinSeconds;

    private float startTime;
    private int machineStatus;
    private List<string> toyParts;
    private int numberOfCopies;

    // Start is called before the first frame update
    void Start()
    {
        machineStatus = 0; // 0 = off, 1 = on, 2 = auto
        startTime = Time.time;
        toyParts = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

        if(machineStatus > 0)
        {
            if(numberOfCopies > 0)
            {
                if(Time.time - startTime > delayBetweenCopiesinSeconds)
                {
                    checkPartsList();
                    numberOfCopies--;
                    startTime = Time.time;
                }
            }
        }
    }

    public void setMachineStatus(int status)
    {
        machineStatus = status;
    }

    private void checkPartsList()
    {
        
        if(toyParts.Count > 2)
        {
            GameObject newToy =  GameObject.Instantiate(toy);
            newToy.transform.Translate(toySpawnLocation, Space.World);
            updatePartsListDisplay();
        }
    }

    public void updatePartsListDisplay()
    {
        string partsText = "";

        foreach (string s in toyParts)
        {
            partsText += s + "\n";
        }

        partsList.text = "Current Parts:\n" + partsText;
    }

    public void setNumberOfCopies(int copies)
    {
        numberOfCopies = copies;
    }

    // Adds a toy part to the List object
    public void addToyPart(string part)
    {
        toyParts.Add(part);
    }

    // Clears the list
    public void clearToyPartsList()
    {
        toyParts.Clear();
    }
}
