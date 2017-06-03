using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject p;
    Rigidbody2D rb;
    public float speed;//1 for movetoward, 0.005 for playermove
    public float speedMod;
    float alertTimer = 5f;
    int dirX, dirY;
    Vector3 startPos, endPos;
    public List<GameObject> checkBoxes;
    Animator anim;
    bool isMoving = false;

    float aggro = 0;

    public void CalculateMove()
    {
        if (Mathf.Approximately(transform.position.x, p.transform.position.x))
        {
            dirX = 0;
        }
        else if (transform.position.x < p.transform.position.x)
        {
            dirX = 1;
        }
        else dirX = -1;

        if (Mathf.Approximately(transform.position.y, p.transform.position.y))
            dirY = 0;
        else if (transform.position.y < p.transform.position.y)
        {
            dirY = 1;
        }
        else dirY = -1;

    }


    protected void Move(int xDir, int yDir)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        StartCoroutine(SmoothMovement(transform, new Vector2(dirX, dirY)));
        //StartCoroutine(SmoothMovement(p.transform.position));
        
    }

    IEnumerator SmoothMovement(Transform entity, Vector2 input)
    {

        float t;
        isMoving = true;
        startPos = entity.position;
        t = 0f;
        const float interval = 1f;
        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (t < interval)
        {
            t += (Time.deltaTime + speed * speedMod) / 2;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
        isMoving = false;
        yield return 0;

    }

    //void AttemptMove(int xDir, int yDir)
    //{
    //    RaycastHit2D hit;

    //    bool canMove = Move(xDir, yDir, out hit);

    //    if (hit.transform == null)
    //        return;

    //    //T hitComponent = hit.transform.GetComponent<T>();

    //    //If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
    //    //if (!canMove && hitComponent != null) { };
    //        //OnCantMove(hitComponent);
    //}

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb.position, end, speed * Time.deltaTime);
            transform.position = newPostion;
            //rb.MovePosition(newPostion);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 4; i++)
        {
            checkBoxes[i] = new GameObject("checkBox");
            checkBoxes[i].gameObject.tag = "Ignored";
            checkBoxes[i].AddComponent<BoxCollider2D>();
            checkBoxes[i].transform.SetParent(gameObject.transform);
            checkBoxes[i].GetComponent<BoxCollider2D>().isTrigger = true;
            checkBoxes[i].GetComponent<BoxCollider2D>().size = new Vector2(0.3f, 0.3f);
            checkBoxes[i].AddComponent<EnemyAttack>();
        }
        checkBoxes[0].transform.position = new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y);
        checkBoxes[1].transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
        checkBoxes[2].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
        checkBoxes[3].transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);

        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update () {
        if (p != null && Vector2.Distance(transform.position, p.transform.position) >= 1)
        {
            //임시조치
            //float step = speed * Time.deltaTime;
            //transform.position = Vector2.MoveTowards(transform.position, p.transform.position, step);
            //Debug.Log("chasing");

            CalculateMove();
            AttemptMove();
            Move(dirX, dirY);
            anim.SetFloat("X", dirX);
            anim.SetFloat("Y", dirY);

            Debug.Log(dirX + " " + dirY);

        }
	}

    private void AttemptMove()
    {
        if (dirX != 0 && dirY != 0)
        {
            var i = UnityEngine.Random.Range(-50,50);
            Mathf.Clamp(i, 0,1);
            if (i == 0)
            {
                dirY = 0;
            }
            else
            {
                dirX = 0;
            }
        }
    }
}
