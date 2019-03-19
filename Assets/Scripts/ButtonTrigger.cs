using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    AudioSource buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MachineInputField").GetComponent<InputField>().text = "Machine Status: Off";
        buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject keypadInputField = GameObject.Find("KeypadInputField");
        GameObject machineInputField = GameObject.Find("MachineInputField");
        
        string parentName = other.gameObject.transform.parent.gameObject.name;
        int keypadTextlength = keypadInputField.GetComponent<InputField>().text.Length;
        buttonSound.Play();

        if (int.TryParse(parentName, out int result))
        {
            keypadInputField.GetComponent<InputField>().text += result;
        }
        else
        {
            if(parentName.Equals("Backspace") && keypadTextlength > 0)
            {
                keypadInputField.GetComponent<InputField>().text = keypadInputField.GetComponent<InputField>().text.Remove(keypadTextlength - 1, 1);
                Debug.Log("backspace");
            }
            else if(parentName.Equals("Enter") && keypadTextlength > 0)
            {

                int number = int.Parse(keypadInputField.GetComponent<InputField>().text);

                GameObject.Find("ToyMachine").GetComponent<MachineController>().numberOfCopies = number;
                keypadInputField.GetComponent<InputField>().text = string.Empty;
            }

            // Machine Menu
            if (parentName.Equals("On"))
            {
                machineInputField.GetComponent<InputField>().text = "Machine Status: On";
                GameObject.Find("ToyMachine").GetComponent<MachineController>().setMachineStatus(1);
            }
            else if (parentName.Equals("Off"))
            {
                machineInputField.GetComponent<InputField>().text = "Machine Status: Off";
                GameObject.Find("ToyMachine").GetComponent<MachineController>().setMachineStatus(0);

            }
            else if (parentName.Equals("Auto"))
            {
                machineInputField.GetComponent<InputField>().text = "Machine Status: Auto";
                GameObject.Find("ToyMachine").GetComponent<MachineController>().setMachineStatus(2);

            }
            else if (parentName.Equals("ResetParts"))
            {
                GameObject machineEntrance = GameObject.Find("MachineEntrance");
                MachineEntrance machineEntrance_instance = machineEntrance.GetComponentInChildren<MachineEntrance>();
                machineEntrance_instance.getPartsList().Clear();
                machineEntrance_instance.updateListDisplay();

            }

        }
    }
}
