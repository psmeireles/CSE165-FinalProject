using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text hudText;
    public Text timer;
    public static Text warning;
    float startTime;
    bool finished;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        finished = false;
        warning = GameObject.Find("Warning").GetComponent<Text>();
        warning.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(FinishedToysTable.remainingTables != 0 && ! finished) {
            hudText.text = "Remaining tables: " + FinishedToysTable.remainingTables.ToString();
            timer.text = "Elapsed time: " + (Time.time - startTime).ToString("0.00");
        }
        else {
            hudText.text = "Finished!";
            finished = true;
        }
    }
}
