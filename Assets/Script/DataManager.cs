using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public List<string> saveList;// = new List<string>();
    string saveData;
    public string loadData;
    public string globalLoc;
    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataManager();
            }
            return instance;
        }
    }
    GameObject player;
    PlayerSpawner playerSpawner;
    PlayerLocation playerLocation;
    //QuestLog


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //instance = this;
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save()
    {
        if (player == null)
        {
            Debug.Log("No player");
            player = GameObject.FindWithTag("Player");
        }
        playerLocation = player.GetComponent<PlayerLocation>();


        if (playerLocation == null)
        {
            Debug.Log("save null");
            playerLocation = player.GetComponent<PlayerLocation>();
        }

        Debug.Log("save");
        saveData = JsonUtility.ToJson(playerLocation.locationData);
        var globalLoc = JsonUtility.ToJson(player.transform.position);

        PlayerPrefs.SetInt("isSaved", 1);
        PlayerPrefs.SetInt("questProgress", QuestManager.instance.questProgress);
        PlayerPrefs.SetString("save", saveData);
        PlayerPrefs.SetString("globalLoc", globalLoc);
        Debug.Log(saveData);
        Debug.Log(globalLoc);
    }

    //not use
    public void Load()
    {
        //playerLocation = GameObject.FindWithTag("Player").GetComponent<PlayerLocation>();

        Debug.Log("load");
        loadData = PlayerPrefs.GetString("save");
        globalLoc = PlayerPrefs.GetString("globalLoc");
        Debug.Log(loadData);
        Debug.Log(globalLoc);

        if (playerSpawner == null)
        {
            playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        }
        playerSpawner.Load();
        //playerSpawner.PlayerSpawn(loadData, globalLoc);//spawns player in title scene.

        //JsonUtility.FromJsonOverwrite(loadData, playerLocation.locationData);
        //playerLocation.locationData = JsonUtility.FromJson<PlayerLocation.LocationData>(loadData);
    }



}
