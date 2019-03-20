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
        GameObject toyNameField = GameObject.Find("ToyNameField");
        GameObject keypadInputField = GameObject.Find("KeypadInputField");
        GameObject machineInputField = GameObject.Find("MachineInputField");
        MachineController machineController = GameObject.Find("ToyMachine").GetComponent<MachineController>();
        
        string parentName = other.gameObject.transform.parent.gameObject.name;
        int keypadTextlength = keypadInputField.GetComponent<InputField>().text.Length;
        if(other.gameObject.tag == "Button") {
            buttonSound.Play();
        }

        // Numbers on keypad
        if (int.TryParse(parentName, out int result))
        {
            keypadInputField.GetComponent<InputField>().text += result;
        }
        else
        {
            // Keypad menu
            if(parentName.Equals("Backspace") && keypadTextlength > 0)
            {
                keypadInputField.GetComponent<InputField>().text = keypadInputField.GetComponent<InputField>().text.Remove(keypadTextlength - 1, 1);
            }
            else if(parentName.Equals("Enter") && keypadTextlength > 0)
            {
                int count = int.Parse(keypadInputField.GetComponent<InputField>().text);
                string name = toyNameField.GetComponent<InputField>().text;
                int toyNum = int.Parse(name.Substring(name.Length - 1));
               
                machineController.addToQueue(name, count, toyNum);
                machineController.setNumberOfCopies(count);
                keypadInputField.GetComponent<InputField>().text = string.Empty;
                toyNameField.GetComponent<InputField>().text = string.Empty;
            }

            // Machine Menu
            if (parentName.Equals("On"))
            {
                machineInputField.GetComponent<InputField>().text = "Machine Status: On";
                machineController.setMachineStatus(1);
            }
            else if (parentName.Equals("Off"))
            {
                machineInputField.GetComponent<InputField>().text = "Machine Status: Off";
                machineController.setMachineStatus(0);
            }
            else if (parentName.Equals("Auto"))
            {
                machineInputField.GetComponent<InputField>().text = "Machine Status: Auto";
                machineController.setMachineStatus(2);
            }
            else if (parentName.Equals("ResetParts"))
            {
                machineController.clearToyPartsList();
            }

            // Toy Selection Menu
            if (parentName.Equals("Toy1"))
            {
                toyNameField.GetComponent<InputField>().text = "Toy 1";
            }
            else if (parentName.Equals("Toy2"))
            {
                toyNameField.GetComponent<InputField>().text = "Toy 2";
            }
            else if (parentName.Equals("Toy3"))
            {
                toyNameField.GetComponent<InputField>().text = "Toy 3";
            }
            else if (parentName.Equals("Toy4"))
            {
                
            }
        }
    }
}
