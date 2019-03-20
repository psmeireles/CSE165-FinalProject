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

        public int getToyCount()
        {
            return count;
        }

        public int getToyNum()
        {
            return toyNum;

        }

        public string getToyName()
        {
            return name;
        }

        public void decrementCount()
        {
            toyNum--;
        }
    }
    public GameObject toy1;
    public GameObject toy2;
    public GameObject toy3;
    public Vector3 toySpawnLocation;
    public Text partsListText;
    public Text machineQueueText;
    public int delayBetweenCopiesinSeconds;
    public Transform machine;

    private float startTime;
    private int machineStatus;
    private List<string> toyParts;
    private int numberOfCopies;

    private int []toyPartsCounter;
    private int maxToys = 0;

    private List<ToyRecipe> toyRecipes;
    private List<QueueItem> machineQueue;
    private AudioSource machineSound;
    private string currBuildingToy;
    private int currBuildingToyCount;

    // Start is called before the first frame update
    void Start()
    {
        machineQueue = new List<QueueItem>();
        machineStatus = 0; // 0 = off, 1 = on, 2 = auto
        startTime = Time.time;
        toyParts = new List<string>();
        
        toyPartsCounter = new int[3];
        machineSound = GetComponent<AudioSource>();
        currBuildingToy = "";
        currBuildingToyCount = -1;
    }

    // Update is called once per frame
    void Update()
    {

        if(machineStatus > 0) // not off
        {
            if(machineStatus == 1) // status = on
            {
                
            }

            if(machineStatus == 2) // status = auto
            {

            }

            if (machineQueue.Count > 0)
            {
                // Builds the first toy in the queue
                QueueItem currentToy = machineQueue[0];
                currBuildingToy = currentToy.getToyName();
                currBuildingToyCount = currentToy.getToyCount();
                if (currentToy.getToyCount() > 0)
                {
                    buildToy(currentToy);
                }
                else // pops the toy when it is done building
                {

                    machineQueue.RemoveAt(0);
                    currBuildingToy = "";
                    currBuildingToyCount = -1;
                }
            }
        }
    }

    private void buildToy(QueueItem toy)
    {
        if (Time.time - startTime > delayBetweenCopiesinSeconds)
        {
            GameObject newToy = GameObject.Instantiate(toyRecipes[toy.getToyNum()].getToy());
            newToy.transform.Translate(toySpawnLocation, Space.World);

            toy.decrementCount();
            //checkToyParts();
            //numberOfCopies--;
            startTime = Time.time;
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

        partsListText.text = "Current Parts:\n" + partsText;
    }

    public void updateMachineQueue()
    {
        string machineText = "Building: " + currBuildingToy + "\n";

        if (currBuildingToyCount > -1)
        {
            machineText += "Amount: " + currBuildingToyCount + "\n\n";
        }
        else
        {
            machineText += "Amount: \n\n";
        }

        machineText += "Queue:\n";
        foreach(QueueItem item in machineQueue)
        {
            machineText += item.getToyName() + "\t\t\t" + item.getToyCount() + "\n";
        }

        machineQueueText.text = machineText;
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
        switch(maxToys)
        {
            case 0:
                recipe.initializeToyObj(toy1);
                break;
            case 1:

                recipe.initializeToyObj(toy2);
                break;
            case 2:

                recipe.initializeToyObj(toy3);
                break;
        }
        toyRecipes.Add(recipe);
        maxToys++;
    }

    public void addToQueue(string name, int count, int toyNum)
    {
        machineQueue.Add(new QueueItem(name, count, toyNum));
        updateMachineQueue();
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
