using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {

    [System.Serializable]
    public struct LocationData
    {
        public int floorNum;
        public int floorX;
        public int floorY;
        public int roomNum;
        public int roomX;
        public int roomY;

    }

    public LocationData locationData;
    [SerializeField] Vector3 offset;

    Vector3 origin;
    GameManager gameManager;

    Vector3 location;

    // Use this for initialization
    void Start () {
        //origin = GameObject.Find("GameManager").transform.position;
        //origin = GameObject.Find("GameManager").GetComponent<GameManager>().floor[0].transform.position;

    }
    public void Init()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        origin = gameManager.floor[0].transform.position;
    }
    // Update is called once per frame
    void Update () {

        //Debug.Log(origin = GameObject.
        //    FindObjectOfType<GameManager>().
        //    GetComponent<GameManager>().
        //        floor[
        //    GameObject.FindObjectOfType<PlayerLocation>().
        //    locationData.
        //    floorNum].
        //    transform.
        //    position);

        //should be refactored to playerlocation, not if-else expression...
        if (this.gameObject.CompareTag("Player"))
        {
            var player = GameObject.FindWithTag("Player");

            origin = gameManager.
                //floor[GameObject.FindWithTag("Player").GetComponent<PlayerLocation>().locationData.floorNum].transform.position;
                floor[player.GetComponent<PlayerLocation>().locationData.floorNum].transform.position;
        }
        else
        {
            origin = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().
                floor[locationData.floorNum].transform.position;
        }


        locationData.floorX = Mathf.RoundToInt(transform.position.x - origin.x);
        locationData.floorY = Mathf.RoundToInt(transform.position.y - origin.y);


	}
}
