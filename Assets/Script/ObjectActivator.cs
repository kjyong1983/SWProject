using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour {

    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target.SetActive(true);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
