using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //player settings
    PlayerSpawner playerSpawner;
    PlayerLocation playerLocation;
    TouchPadController touchPadController;
    PlayerAnimator playerAnimator;
    PlayerController playerController;

    public GameObject player;
    public bool isSpawnReady = false;



    public List<GameObject> floor;
    public int curFloor = 0;
    
    private static GameManager instance;

    internal float GetHeight(int floor)
    {
        if (floor == 1)
        {
            return 30;
        }
        else if (floor == 8)
        {
            return 31;
        }
        else
        {
            return 58;
        }
    }

    public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public bool showGrid = true;

    private void Awake()
    {

        playerSpawner = FindObjectOfType<PlayerSpawner>();
        if (playerSpawner == null)
        {
            playerSpawner = this.gameObject.AddComponent<PlayerSpawner>();
        }

        Debug.Log("continue : " + UIManager.isContinue);
        if (UIManager.isContinue)
        {
            var loadData = PlayerPrefs.GetString("save");
            var questProgress = PlayerPrefs.GetInt("questProgress");
            var globalLoc = PlayerPrefs.GetString("globalLoc");

            if (loadData == null || globalLoc == null)
            {
                playerSpawner.NewGame();
                return;
            }

            playerSpawner.PlayerSpawn(loadData, globalLoc);
            QuestManager.instance.questProgress = questProgress;
            Debug.Log("Load game : quest Progress" + questProgress);
        }
        //if (playerLocation == null)
        else
        {
            playerSpawner.NewGame();
            //playerLocation = FindObjectOfType<PlayerLocation>();
        }
        playerLocation = FindObjectOfType<PlayerLocation>();

        playerLocation.Init();
        touchPadController = FindObjectOfType<TouchPadController>();
        touchPadController.Init();
        playerAnimator = FindObjectOfType<PlayerAnimator>();
        //playerAnimator.Init();

        player = GameObject.FindWithTag("Player");
        floor[0] = gameObject;

        isSpawnReady = true;


    }
    // Use this for initialization
    void Start () {
        if (GameObject.FindWithTag("Player") == null)
        {
            playerSpawner.NewGame();
        }
	}
	
    private void OnDrawGizmos()
    {

        if (showGrid)
        {
            Gizmos.color = Color.yellow;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Gizmos.DrawWireCube(new Vector3(transform.position.x + j, transform.position.y + i), new Vector3(1f, 1f));
                }
            }

        }

    }

}
