using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour {

    [SerializeField] GameObject objectInfo;
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

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.gameObject.transform.parent.tag == "Item")
        {
            Debug.Log("Item Dectected");
            objectInfo = other.transform.parent.gameObject;
            Debug.Log(objectInfo.GetComponent<Item>().id);
            IsObstacle = true;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            objectInfo = other.transform.parent.gameObject;
            Debug.Log("Wall Dectected");
            IsObstacle = true;
        }
        if (other.transform.parent.tag == "Warp")
        {
            Debug.Log("Warp Detected");
            IsObstacle = false;
            return;
        }
        objectInfo = other.transform.parent.gameObject;
        IsObstacle = true;

    }

    public void OnTriggerExit(Collider other)
    {
        objectInfo = null;
        IsObstacle = false;
    }
}
