using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Direction { up, down, left, right};
    public Direction dir;
    Rigidbody rb;
    Vector2 input;
    float v, h;
    public float moveSpeed;
    public float walkSpeed; //3f
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Move(v, h);
        GetInput(h, v);

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

    private void GetInput(float h, float v)
    {
        if (!isMoving)
        {
            input = new Vector2(h, v);
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

            if (input != Vector2.zero)
            {
                StartCoroutine(Move(transform));
            }
        }
    }

    IEnumerator Move(Transform entity)
    {
        isMoving = true;
        startPos = entity.position;
        t = 0f;
        float interval = 0.5f;
        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (t < interval)
        {
            t += Time.deltaTime + walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;

    }

    public void Move(Vector3 normDiff)
    {
        //Move(normDiff.y, normDiff.x);
        GetInput(normDiff.x, normDiff.y);
    }

}
