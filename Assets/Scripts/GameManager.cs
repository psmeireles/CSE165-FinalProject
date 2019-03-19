using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public TextAsset stageFile;
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

        StreamReader reader = File.OpenText("Assets/" + stageFile.name + ".txt");
        string line;
        while ((line = reader.ReadLine()) != null) {
            string[] items = line.Split(' ');
            string tableName = "Table " + items[0];
            string toyName = items[1];
            int requiredColors = int.Parse(items[2]);
            int requiredQuantity = int.Parse(items[3].Split('\n')[0]);

            GameObject toy = GameObject.Find(toyName);
            FinishedToysTable table1 = GameObject.Find(tableName).GetComponentInChildren<FinishedToysTable>();

            table1.toy = toy;
            table1.numberOfColorsRequired = requiredColors;
            table1.numberOfToysRequired = requiredQuantity;
        }
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
