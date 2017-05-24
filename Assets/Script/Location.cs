using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {

    public int floorNum;
    public int floorX;
    public int floorY;
    public int roomNum = 0;
    public int roomX;
    public int roomY;



    [SerializeField] Vector3 offset;

    Vector3 origin;
    GameManager gameManager;

    Vector3 location;

    // Use this for initialization
    void Start () {
        origin = GameObject.Find("GameManager").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        floorX = Mathf.RoundToInt(transform.position.x - origin.x);
        floorY = Mathf.RoundToInt(transform.position.y - origin.y);


	}
}
