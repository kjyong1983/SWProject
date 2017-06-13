using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Direction { up, down, left, right};
    public Direction dir;
    public Direction prevDir;

    [SerializeField] bool isNewGame = true;
    [SerializeField]Vector2 input;
    Vector2 lastInput;
    float v, h;
    public float moveSpeed; //3f

    public int hp = 1;
    bool isMoving = false;
    public bool IsMoving { set; get; }
    public bool canMove = true;
    Vector3 startPos;
    Vector3 endPos;

    public bool fadeTrigger = false;
    PlayerAnimator anim;

    private void Awake()
    {
        dir = Direction.down;
        prevDir = Direction.down;
        anim = GetComponent<PlayerAnimator>();
        anim.SetLastMove(DirToVector2(prevDir));
    }

    void Start () {
        //if (isNewGame)
        if(!UIManager.isContinue)
        {
            var startScene = GameObject.Find("StartScene");
            startScene.GetComponent<NPC>().StartDialogue();
            Debug.Log("startScene");
        }

    }
	
	void Update () {

        h = UnityEngine.Input.GetAxis("Horizontal");
        v = UnityEngine.Input.GetAxis("Vertical");

        if (canMove)
        {
            GetInput(h, v);
        }

        if (hp <= 0)
        {
            //Debug.Log("Game Over");
            //Debug.Break();
        }

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
            }
            else
            {
                input.x = 0;
            }

            lastInput = new Vector2(input.x, input.y);
            anim.SetMove(input);
            anim.SetLastMove(DirToVector2(prevDir));
            SetDirection(input);

            if (input != Vector2.zero)
            {
                if(!CheckDirection())
                {
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

    public Vector2 DirToVector2(Direction dir)
    {
        switch (dir)
        {
            case Direction.up:
                return new Vector2(0, 1);
            case Direction.down:
                return new Vector2(0, -1);
            case Direction.left:
                return new Vector2(-1, 0);
            case Direction.right:
                return new Vector2(1, 0);
            default:
                return new Vector2(0, -1);
        }
    }

    private bool CheckObstacle()
    {
        var interactObject = FindObjectOfType<PlayerInteractTrigger>();

        return interactObject.IsObstacle;
    }

    private IEnumerator Wait()
    {
        isMoving = true;
        Debug.Log("wait");
        yield return new WaitForSeconds(0.1f);
        //자리 보정.
        if (transform.position.x % 1 > 0.01 || transform.position.y % 1 > 0.01)
        {
            transform.position
                = new Vector2(
                    Mathf.RoundToInt(transform.position.x), 
                    Mathf.RoundToInt(transform.position.y)
                    );
        }
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

    }

    void SetDirection(Vector2 input)
    {
        //sameDir = CheckDirection();
        CheckDirection();

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
        const float interval = 1f;
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
