using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0, 0, -10);

	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        transform.position = player.transform.position + offset;
	}
}
