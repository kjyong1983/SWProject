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




    public List<GameObject> floor;
    public int curFloor = 0;
    
    private static GameManager instance;
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
        playerLocation = FindObjectOfType<PlayerLocation>();
        if (playerLocation == null)
        {
            playerSpawner.NewGame();
            playerLocation = FindObjectOfType<PlayerLocation>();
        }
        playerLocation.Init();
        touchPadController = FindObjectOfType<TouchPadController>();
        touchPadController.Init();
        playerAnimator = FindObjectOfType<PlayerAnimator>();
        //playerAnimator.Init();

        player = GameObject.FindWithTag("Player");
        floor[0] = gameObject;
    }
    // Use this for initialization
    void Start () {
        if (GameObject.FindWithTag("Player") == null)
        {
            playerSpawner.NewGame();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
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
