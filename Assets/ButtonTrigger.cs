using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject textfield = GameObject.Find("KeypadInputField");

        //GameObject.Find("KeypadInputField").GetComponent<InputField>().text = other.gameObject.name;
        string parentName = other.gameObject.transform.parent.gameObject.name;
        int textLength = textfield.GetComponent<InputField>().text.Length;

        //other.gameObject.transform.parent.gameObject.name
        //Debug.Log("Button " + parentName + "pressed.");

        if (int.TryParse(parentName, out int result))
        {
            textfield.GetComponent<InputField>().text += result;
        }
        else
        {
            //Debug.Log(parentName);
            if(parentName.Equals("Backspace") && textLength > 0)
            {
                textfield.GetComponent<InputField>().text = textfield.GetComponent<InputField>().text.Remove(textLength - 1, 1);
                Debug.Log("backspace");
            }
            else if(parentName.Equals("Enter") && textLength > 0)
            {

                int number = int.Parse(textfield.GetComponent<InputField>().text);
                textfield.GetComponent<InputField>().text = string.Empty;
            }
        }
        //GameObject.Find("KeypadInputField").GetComponent<InputField>().text
        //int.TryParse()
    }
}
