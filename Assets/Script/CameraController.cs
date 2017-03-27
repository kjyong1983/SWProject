using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0, 0, -10);
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
