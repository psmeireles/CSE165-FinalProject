using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - time > 5) {
            DestroyImmediate(this.gameObject);
        }
    }
}
