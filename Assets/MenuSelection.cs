using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    public Text sampleText;

    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() => ButtonClick("button1"));
        button2.onClick.AddListener(() => ButtonClick("button2"));
        button3.onClick.AddListener(() => ButtonClick("button3"));
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void ButtonClick(string text)
    {
        sampleText.text = text;
    }
}
