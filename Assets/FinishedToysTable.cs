using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedToysTable : MonoBehaviour
{
    public static int remainingTables = 0;
    public GameObject toy;
    public int numberOfColorsRequired;
    public int numberOfToysRequired;
    private List<GameObject> correctToys;
    AudioSource correctSound;
    // Start is called before the first frame update
    void Start()
    {
        remainingTables++;
        correctToys = new List<GameObject>();
        correctSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject obj = collision.gameObject;

        if (obj.name.Contains(toy.name)) {
            List<Color> differentColors = new List<Color>();
            MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
            foreach(Renderer r in renderers) {
                Color materialColor = r.material.color;
                var a = differentColors.Find(x => x.Equals(materialColor));
                if (differentColors.Find(x => x.Equals(materialColor)) == new Color(0, 0, 0, 0)){
                    differentColors.Add(materialColor);
                }
            }
            if(differentColors.Count >= numberOfColorsRequired) {
                if(numberOfToysRequired > 0) {
                    numberOfToysRequired--;
                    if (numberOfToysRequired == 0) {
                        remainingTables--;
                    }
                }
                correctToys.Add(obj);
                correctSound.Play();
            }
        }

        Debug.Log("Remaining toys: " + numberOfToysRequired.ToString());
        Debug.Log("Remaining tables: " + remainingTables.ToString());
    }

    void OnCollisionExit(Collision col) {
        if(correctToys.Find(x => x == col.gameObject) != null) {
            correctToys.Remove(col.gameObject);
            if(numberOfToysRequired == 0) {
                remainingTables++;
            }
            numberOfToysRequired++;
        }   
    }
}
