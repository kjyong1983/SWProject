using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject p;
    [SerializeField]GameObject shadow;
    Rigidbody2D rb;
    public float speed;//2.5 for movetoward, 0.005 for playermove
    public float speedMod;
    [SerializeField]float alertTimer = 0f;
    const float alertMax = 3f;
    int dirX, dirY;
    Vector3 startPos, endPos;
    Vector3 initPos;
    public List<GameObject> checkBoxes;
    Animator anim;
    bool isMoving = false;
    bool isIdle = true;

    float aggro = 0;

    public void CalculateMove(Vector3 otherPos)
    {
        float x = otherPos.x - transform.position.x;
        float y = otherPos.y - transform.position.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            dirX = Math.Sign(x);
            dirY = 0;
        }
        else
        {
            dirX = 0;
            dirY = Math.Sign(y);
        }
    
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        initPos = gameObject.transform.position;
        
        for (int i = 0; i < 4; i++)
        {
            checkBoxes[i] = new GameObject("checkBox");
            checkBoxes[i].gameObject.tag = "Ignored";
            checkBoxes[i].AddComponent<BoxCollider2D>();
            checkBoxes[i].transform.SetParent(gameObject.transform);
            checkBoxes[i].GetComponent<BoxCollider2D>().isTrigger = true;
            checkBoxes[i].GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.5f);
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
            isIdle = false;
            //임시조치
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, p.transform.position, step);
            //Debug.Log("chasing");

            CalculateMove(p.transform.position);
            //AttemptMove();
            //Move(dirX, dirY);
            anim.SetFloat("X", dirX);
            anim.SetFloat("Y", dirY);
            anim.SetBool("isMoving", true);
            Debug.Log(dirX + " " + dirY);

            shadow = p;
            alertTimer = alertMax;

        }
        else if (alertTimer > 0 && shadow != null)
         {
            isIdle = false;

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, shadow.transform.position, step);
            CalculateMove(shadow.transform.position);

            anim.SetFloat("X", dirX);
            anim.SetFloat("Y", dirY);
            anim.SetBool("isMoving", true);

         }
        else if(alertTimer <= 0.1)
        {
            isIdle = false;

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, initPos, step);
            CalculateMove(initPos);

            anim.SetFloat("X", dirX);
            anim.SetFloat("Y", dirY);
            anim.SetBool("isMoving", true);
        }


        if (p == null && shadow == null)
        {
            if (Vector3.Equals(gameObject.transform.position, initPos))
            {
                isIdle = true;
                anim.SetBool("isMoving", false);
            }
        }

        if (alertTimer > 0)
        {
            alertTimer -= Time.deltaTime;
        }

        if (alertTimer <= 0)
        {
            shadow = null;
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
