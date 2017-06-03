using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    float x = -280f;//-275f
    float y = 35f;//-18.5f

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
    }

    public void PlayerSpawn(string savedData, string globalLoc)
    {





        JsonUtility.FromJsonOverwrite(savedData, playerPrefab.gameObject.GetComponent<PlayerLocation>().locationData);
        JsonUtility.FromJsonOverwrite(globalLoc, playerPrefab.gameObject.transform.position);
        
        Instantiate(playerPrefab, playerPrefab.gameObject.transform.position, Quaternion.identity);

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
