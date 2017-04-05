﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperAuto : MonoBehaviour {

    public GameObject dest;

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
            var player = other.GetComponent<PlayerController>();
            if (player.ReadyToWarp)
            {
                player.ReadyToWarp = false;
            }
            else
                return;
            
            other.transform.position = dest.transform.position;
            Debug.Log("teleport");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerController>();

            if (!player.ReadyToWarp)
            {
                player.ReadyToWarp = true;
            }
        }
    }

}
