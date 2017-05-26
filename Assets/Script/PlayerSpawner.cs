using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;
    GameManager gameManager;
    public PlayerState playerState;
    [SerializeField] bool isTriggered = false;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        PlayerSpawn();

	}

    private void PlayerSpawn()
    {
        Instantiate(playerPrefab, new Vector3(-85.5f, -64.5f), Quaternion.identity);

        //Instantiate(playerPrefab, new Vector3(
        //    gameManager.floor[GameObject.Find("Player").GetComponent<PlayerLocation>().floorNum].
        //        transform.position.x + playerPrefab.GetComponent<PlayerLocation>().floorX,
        //    gameManager.floor[GameObject.Find("Player").GetComponent<PlayerLocation>().floorNum].
        //        transform.position.y + playerPrefab.GetComponent<PlayerLocation>().floorY), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
