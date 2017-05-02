using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperAuto : MonoBehaviour {

    public GameObject dest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Warp>();
            if (player.ReadyToWarp)
            {
                player.ReadyToWarp = false;
            }
            else
                return;
            
            other.transform.position = dest.transform.position;//rigidbody가 맨 위에 있어야 작동함.
            Debug.Log("teleport");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Warp>();

            if (!player.ReadyToWarp)
            {
                player.ReadyToWarp = true;
            }
        }
    }

}
