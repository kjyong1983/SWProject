using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLocator : MonoBehaviour {

    public int floor;
    public float x;
    public float y;

    Vector3 floorOrigin;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
        floorOrigin = gameManager.floor[floor].transform.position;

        Debug.Log("floorOrigin " + floorOrigin);
        //Debug.Break();

        transform.position = new Vector3(floorOrigin.x + x, floorOrigin.y + gameManager.getHeight(floor) - y);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
