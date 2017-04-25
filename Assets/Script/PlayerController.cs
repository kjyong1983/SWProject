using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameObject itactObject;
    Rigidbody rb;
    float v, h;
    public float moveSpeed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Move(v, h);

    }

    void Move(float v, float h)
    {
        float playerdx = 0;
        float playerdy = 0;


        if (h > 0.2 || h < -0.2)
        {
            playerdx = h * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(playerdx) > 0)
            {
                playerdx = 0;
            }

        }

        if (v > 0.2 || v < -0.2)
        {
            playerdy = v * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(playerdy) > 0)
            {
                playerdy = 0;
            }

        }
        
        rb.velocity = new Vector3(playerdx, playerdy, rb.velocity.z);

    }

    public void Move(Vector3 normDiff)
    {
        Move(normDiff.y, normDiff.x);
    }

    private void OnTriggerEnter(Collider other)
    {
        itactObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        itactObject = null;
    }

}
