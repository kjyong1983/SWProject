using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    float x = -289f;//-289f, -280
    float y = -20.5f;//-20.5f, 35

    static PlayerSpawner instance;
    public PlayerSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerSpawner();
            }
            return instance;
        }
    }

    public GameObject playerPrefab;
    GameManager gameManager;
    //public PlayerState playerState;
    [SerializeField] bool isTriggered = false;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find("GameManager") != null)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();//.GetComponent<GameManager>();
        }
        playerPrefab = Resources.Load("Prefab/Player") as GameObject;
        //PlayerSpawn();
	}

    private void Start()
    {
        //NewGame();
    }

    public void NewGame()
    {
        var player =  Instantiate(playerPrefab, new Vector3(x, y), Quaternion.identity);
        player.GetComponent<PlayerLocation>().locationData.floorNum = 3;//defalut
        DontDestroyOnLoad(player);

        //why playercontroller go off?
        player.GetComponent<PlayerController>().enabled = true;

    }

    public void PlayerSpawn(string savedData, string globalLoc)
    {
        int newFloorNum = JsonUtility.FromJson<PlayerLocation.LocationData>(savedData).floorNum;

        //JsonUtility.FromJsonOverwrite(savedData, playerPrefab.gameObject.GetComponent<PlayerLocation>().locationData);
        //JsonUtility.FromJsonOverwrite(globalLoc, playerPrefab.gameObject.transform.position);
        var newPos = JsonUtility.FromJson<Vector3>(globalLoc);
        //Instantiate(playerPrefab, playerPrefab.gameObject.transform.position, Quaternion.identity);
        var newPlayer = Instantiate(playerPrefab, newPos, Quaternion.identity)as GameObject ;
        newPlayer.GetComponent<PlayerLocation>().locationData.floorNum = newFloorNum;


        //Instantiate(playerPrefab, new Vector3(
        //    gameManager.floor[GameObject.Find("Player").GetComponent<PlayerLocation>().floorNum].
        //        transform.position.x + playerPrefab.GetComponent<PlayerLocation>().floorX,
        //    gameManager.floor[GameObject.Find("Player").GetComponent<PlayerLocation>().floorNum].
        //        transform.position.y + playerPrefab.GetComponent<PlayerLocation>().floorY), Quaternion.identity);
    }

    internal void Load()
    {
        //if (SceneMa)
        //{

        //}

        if (gameManager == null)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
        }
        if (gameManager.isSpawnReady == true)
        {
            PlayerSpawn(DataManager.Instance.loadData, DataManager.Instance.globalLoc);
        } 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
