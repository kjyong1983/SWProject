using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    //float attackTimer = 0.5f;
    //bool attackTrigger = false;

    // Use this for initialization
    bool isObstacle = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isObstacle = true;
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Attacked");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isObstacle = false;
    }
}
