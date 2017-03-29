using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GameObject itactObject;
    float v, h;
    Rigidbody rb;
    public float moveSpeed;
    float playerdx;
    float playerdy;
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
            playerdx = h * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(playerdx) > 0)
            {
                playerdx = 0;
                //Mathf.Lerp(playerMoveSpeed, 0, 0.5f);
            }

        }

        if (v > 0.2 || v < -0.2)
        {
            //rb.velocity = new Vector3(h * moveSpeed * Time.deltaTime, rb.velocity.y);
            playerdy = v * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(playerdy) > 0)
            {
                playerdy = 0;
                //Mathf.Lerp(playerMoveSpeed, 0, 0.5f);
            }

        }



        rb.velocity = new Vector3(playerdx, playerdy, rb.velocity.z);




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
