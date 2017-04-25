using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    bool readyToWarp;
    public bool ReadyToWarp
    {
        get { return readyToWarp; }
        set { readyToWarp = value; }
    }




    // Use this for initialization
    void Start () {
        ReadyToWarp = true;

    }

    // Update is called once per frame
    void Update () {
        if (readyToWarp && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("warp");
        }

    }
}
