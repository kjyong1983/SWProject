using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractTrigger : MonoBehaviour {

    public GameObject objectInfo;
    public GameObject collisionInfo;
    bool isObstacle;
    public bool IsObstacle
    {
        get; set;
    }

	// Use this for initialization
	void Start () {
        Debug.Log("InteractTrigger init");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckObject(Collider2D other)
    {
        //Debug.Log("TriggerEnter");
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item Dectected");
            objectInfo = other.gameObject;
            //Debug.Log(objectInfo.GetComponent<Item>().id);
            IsObstacle = true;
            return;
        }
        else if (other.CompareTag("Wall"))
        {
            collisionInfo = other.gameObject;
            Debug.Log("Wall Dectected");
            IsObstacle = true;
            return;
        }
        else if (other.CompareTag("Warp"))
        {
            Debug.Log("Warp Detected");
            objectInfo = other.gameObject;
            isObstacle = false;
            return;
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Detected");
            objectInfo = other.gameObject;
            return;
        }
        else if (other.CompareTag("Ignored"))
        {
            isObstacle = false;
            return;
        }
        else
        {
            objectInfo = other.gameObject;
            IsObstacle = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        CheckObject(other);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        CheckObject(other);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        objectInfo = null;
        IsObstacle = false;
    }
}
