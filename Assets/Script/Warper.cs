using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour {

    public string warperTag;
    public GameObject destination;
    bool warp = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warp = false;
        }
    }


}
