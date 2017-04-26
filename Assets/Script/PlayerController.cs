using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Direction { up, down, left, right};
    public Direction dir;
    Vector2 input;
    float v, h;
    public float moveSpeed; //3f
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;


    // Use this for initialization
    void Start () {
        dir = Direction.down;
	}
	
	// Update is called once per frame
	void Update () {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        GetInput(h, v);
        SetDirection(input);
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

    void SetDirection(Vector2 input)
    {
        if (input.x < 0 && input.y == 0)
        {
            dir = Direction.left;
        }
        if (input.x > 0 && input.y == 0)
        {
            dir = Direction.right;
        }
        if (input.x == 0 && input.y > 0)
        {
            dir = Direction.up;
        }
        if (input.x == 0 && input.y < 0)
        {
            dir = Direction.down;
        }


    }

    IEnumerator Move(Transform entity)
    {
        isMoving = true;
        startPos = entity.position;
        t = 0f;
        float interval = 1f;
        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (t < interval)
        {
            t += (Time.deltaTime + moveSpeed)/2;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;

    }

    public void Move(Vector3 normDiff)
    {
        GetInput(normDiff.x, normDiff.y);
    }

}
