using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    GameObject interactCollider;
    PlayerController p;
    PlayerController.Direction dir;

	// Use this for initialization
	void Start () {
        p = GetComponent<PlayerController>();
        interactCollider = new GameObject("intactCol");
        interactCollider.AddComponent<BoxCollider>();
        interactCollider.transform.SetParent(gameObject.transform);
        interactCollider.GetComponent<BoxCollider>().isTrigger = true;

	}
	
	// Update is called once per frame
	void Update () {
        dir = p.dir;
        SetColLocation(dir);
    }

    void SetColLocation(PlayerController.Direction dir)
    {
        switch (dir)
        {
            case PlayerController.Direction.up:
                interactCollider.transform.position = new Vector3(transform.position.x, transform.position.y + 1);
                break;
            case PlayerController.Direction.down:
                interactCollider.transform.position = new Vector3(transform.position.x, transform.position.y - 1);
                break;
            case PlayerController.Direction.left:
                interactCollider.transform.position = new Vector3(transform.position.x - 1, transform.position.y);
                break;
            case PlayerController.Direction.right:
                interactCollider.transform.position = new Vector3(transform.position.x + 1, transform.position.y);
                break;
            default:
                break;
        }
    }
}
