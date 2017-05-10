using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour/*, IMovable*/ {

    public GameObject p;
    Rigidbody rb;
    public float speed;

    public bool CheckDirection()
    {
        throw new NotImplementedException();
    }

    public IEnumerator Move()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (p != null && Vector2.Distance(transform.position, p.transform.position) >= 1)
        {
            //임시조치
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, p.transform.position, step);
        }
	}
}
