using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameObject itactObject;
    float v, h;
    Rigidbody rb;
    public float moveSpeed;
    float playerMoveSpeed;
    bool readyToWarp;
    public bool ReadyToWarp
    {
        get { return readyToWarp; }
        set { readyToWarp = value; }
    }


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        ReadyToWarp = true;
	}
	
	// Update is called once per frame
	void Update () {

        //h = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        move(v, h);

        if (readyToWarp && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("warp");
            //transform.position = 
        }

    }

    void move(float v, float h)
    {
        if (h > 0.2 || h < -0.2)
        {
            //rb.velocity = new Vector3(h * moveSpeed * Time.deltaTime, rb.velocity.y);
            playerMoveSpeed = h * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(playerMoveSpeed) > 0)
            {
                playerMoveSpeed = 0;
                //Mathf.Lerp(playerMoveSpeed, 0, 0.5f);
            }

        }

        rb.velocity = new Vector3(playerMoveSpeed, rb.velocity.y, rb.velocity.z);




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
