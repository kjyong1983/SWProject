﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Direction { up, down, left, right};
    public Direction dir;
    public Direction prevDir;
    bool sameDir = true;

    [SerializeField]Vector2 input;
    public Vector2 Input { get; set; }
    Vector2 lastInput;
    public Vector2 LastInput { get; set; }
    float v, h;
    public float moveSpeed; //3f

    bool isMoving = false;
    public bool IsMoving { set; get; }
    Vector3 startPos;
    Vector3 endPos;
    //float t;

    PlayerAnimator anim;


    // Use this for initialization
    void Start () {
        dir = Direction.down;
        anim = GetComponent<PlayerAnimator>();
	}
	
	// Update is called once per frame
	void Update () {

        h = UnityEngine.Input.GetAxis("Horizontal");
        v = UnityEngine.Input.GetAxis("Vertical");
        
        GetInput(h, v);


        //콜백으로 prevDir과 dir이 같은지 확인해서 CheckDirection에 넘김.
    }

    public void GetInput(float h, float v)
    {
        if (!isMoving)
        {
            anim.SetIsMoving(isMoving);
            input = new Vector2(h, v);
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
                //LastInput = new Vector2(input.x, 0);
            }
            else
            {
                input.x = 0;
                //LastInput = new Vector2(0, input.y);
            }

            anim.SetMove(input);
            anim.SetLastMove(input);
            SetDirection(input);

            //방향 전환했을 때 멈춰서 방향만 바꾸는거 만들어야함.
            if (input != Vector2.zero)
            {
                if(!CheckDirection())
                {
                    //방향전환만 한다.
                    prevDir = dir;
                    Debug.Log("change direction");
                }
                else if (CheckDirection() && CheckObstacle())
                {
                    Debug.Log("Obstacle Detected");
                    StartCoroutine(Wait());
                }
                else if (CheckDirection() && !CheckObstacle())
                {
                    StartCoroutine(Move(transform, input));
                    //벽에 부딫히는 소리
                }

            }
        }
        anim.SetIsMoving(isMoving);

    }

    private bool CheckObstacle()
    {
        var interactObject = FindObjectOfType<InteractTrigger>();

        return interactObject.IsObstacle;
    }

    private IEnumerator Wait()
    {
        isMoving = true;
        Debug.Log("wait");
        yield return new WaitForSeconds(0.1f);
        isMoving = false;
        yield break;
    }

    private bool CheckDirection()
    {
        if (prevDir == dir)
        {
            return true;
        }
        else
        {
            Debug.Log("change direction");
            StartCoroutine(Wait());
            return false;
        }

        //return prevDir == dir;
    }

    void SetDirection(Vector2 input)
    {
        sameDir = CheckDirection();

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

    IEnumerator Move(Transform entity, Vector2 input)
    {
        float t;
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
