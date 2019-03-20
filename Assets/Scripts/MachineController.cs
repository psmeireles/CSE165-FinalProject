using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineController : MonoBehaviour
{
    struct QueueItem
    {

        string name;
        int count;
        int toyNum;

        public QueueItem(string n, int c, int num)
        {
            name = n;
            count = c;
            toyNum = num;
        }
    }
    public GameObject toy1;
    public GameObject toy2;
    public GameObject toy3;
    public Vector3 toySpawnLocation;
    public Text partsList;
    public int delayBetweenCopiesinSeconds;
    public Transform machine;

    private float startTime;
    private int machineStatus;
    private List<string> toyParts;
    private int numberOfCopies;

    private int []toyPartsCounter;
    private int toynum = 0;

    private List<ToyRecipe> toyRecipes;
    private List<QueueItem> machineQueue;
    private AudioSource machineSound;

    // Start is called before the first frame update
    void Start()
    {
        machineQueue = new List<QueueItem>();
        machineStatus = 0; // 0 = off, 1 = on, 2 = auto
        startTime = Time.time;
        toyParts = new List<string>();
        
        toyPartsCounter = new int[3];
        machineSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(machineStatus > 0) // not off
        {
            if(machineStatus == 1) // status = on
            {
                if (machineQueue.Count > 0)
                {
                    buildToy();
                }
            }

            if(machineStatus == 2) // status = auto
            {
                if(machineQueue.Count > 0)
                {
                    buildToy();
                }
            }
        }
    }

    private void buildToy()
    {
        if (numberOfCopies > 0)
        {
            if (Time.time - startTime > delayBetweenCopiesinSeconds)
            {
                checkToyParts();
                numberOfCopies--;
                startTime = Time.time;
            }
        }
    }
    public void setMachineStatus(int status)
    {
        machineStatus = status;
    }

    private void checkToyParts()
    {
        
        for (int i = 0; i < toyRecipes.Count; i++)
        {


            if (toyRecipes[i].hasEnoughParts(toyPartsCounter[0], toyPartsCounter[1], toyPartsCounter[2]))
            {
                machineSound.Play();
                GameObject newToy = GameObject.Instantiate(toyRecipes[i].getToy());
                newToy.transform.Translate(toySpawnLocation, Space.World);
                updatePartsListDisplay();
            }
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

    public void addToyRecipe(ToyRecipe recipe)
    {
        if(toyRecipes == null)
        {
            
            toyRecipes = new List<ToyRecipe>();
        }
        switch(toynum)
        {
            case 0:
                recipe.initializeToy(toy1);
                break;
            case 1:

                recipe.initializeToy(toy2);
                break;
            case 2:

                recipe.initializeToy(toy3);
                break;
        }
        toyRecipes.Add(recipe);
        toynum++;
    }

    public void addToQueue(string name, int count, int toyNum)
    {
        machineQueue.Add(new QueueItem(name, count, toyNum));
    }
    // Adds a toy part to the List object
    public void addToyPart(string part)
    {
        toyParts.Add(part);

        switch (part)
        {
            case "ToyPartA":
                toyPartsCounter[0]++;
                break;
            case "ToyPartB":
                toyPartsCounter[1]++;
                break;
            case "ToyPartC":
                toyPartsCounter[2]++;
                break;
        }
    }

    // Clears the list
    public void clearToyPartsList()
    {
        toyParts.Clear();
        for (int i = 0; i < toyPartsCounter.Length; i++)
        {
            toyPartsCounter[i] = 0;
        }
        updatePartsListDisplay();
    }
}
