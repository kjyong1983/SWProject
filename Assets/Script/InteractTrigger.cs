using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour {

    [SerializeField]GameObject objectInfo;

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
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            objectInfo = other.transform.parent.gameObject;
            Debug.Log("Wall Dectected");
        }
        objectInfo = other.transform.parent.gameObject;

    }

    public void OnTriggerExit(Collider other)
    {
        objectInfo = null;
    }
}
