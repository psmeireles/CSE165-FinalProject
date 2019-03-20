using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToyRecipe
{
    private string toyName;
    private int A_parts;
    private int B_parts;
    private int C_parts;
    private GameObject toy;
    
    public ToyRecipe(string name, int aCount, int bCount, int cCount)
    {
        toyName = name;
        A_parts = aCount;
        B_parts = bCount;
        C_parts = cCount;
    }

    public bool hasEnoughParts(int aCount, int bCount, int cCount)
    {
        return A_parts <= aCount && B_parts <= bCount && C_parts <= cCount;
    }

    public int subtractAParts(int aCount)
    {
        return aCount - A_parts;
    }
    public int subtractBParts(int bCount)
    {
        return bCount - B_parts;
    }
    public int subtractCParts(int cCount)
    {
        return cCount - C_parts;
    }

    public void initializeToyObj(GameObject obj)
    {
        toy = obj;
    }

    public GameObject getToy()
    {
        return toy;
    }
}
