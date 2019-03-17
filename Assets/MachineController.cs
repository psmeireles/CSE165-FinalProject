using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    public GameObject toy;

    public Vector3 spawnLocation;

    private int machineStatus;
    // Start is called before the first frame update
    void Start()
    {
        machineStatus = 0; // 0 = off, 1 = on, 2 = auto
    }

    // Update is called once per frame
    void Update()
    {
        if(machineStatus > 0)
        {
            checkPartsList();
        }
    }

    public void setMachineStatus(int status)
    {
        machineStatus = status;
    }

    private void checkPartsList()
    {
        GameObject machineEntrance = GameObject.Find("MachineEntrance");
        MachineEntrance machineEntrance_instance = machineEntrance.GetComponentInChildren<MachineEntrance>();
        List<string> parts = machineEntrance_instance.getPartsList();

        if(parts.Count > 4)
        {
            GameObject newToy =  GameObject.Instantiate(toy);
            newToy.transform.Translate(spawnLocation, Space.World);
            machineEntrance_instance.getPartsList().Clear();
            machineEntrance_instance.updateListDisplay();
        }
    }
}
