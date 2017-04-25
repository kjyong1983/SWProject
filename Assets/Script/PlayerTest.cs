using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerTest : MonoBehaviour {

    //Rigidbody rb;
    float h, v;
    float moveSpeed = 150;


	// Use this for initialization
	void Start () {
        //DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        //rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update () {

        //gameObject.transform.DOMove(new Vector3(2, 2, 0), 1f);


        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        MoveByGrid(v, h);




    }

    //private void OnMouseDown()
    //{
    //    Ray ray = GameObject.FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

    //    transform.DOMove(new Vector3(ray.origin.x, ray.origin.y, 0), 1f);//.OnComplete(SnapToGrid);
    //}

    private void MoveByGridDo(float v, float h)
    {
        if (h > 0.2 || h < -0.2)
        {
            transform.DOMoveX(transform.position.x + Mathf.RoundToInt(h), 1f).OnComplete(SnapToGrid);
        }
 
        if (v > 0.2 || v < -0.2)
        {
            transform.DOMoveY(transform.position.y + Mathf.RoundToInt(v), 1f).OnComplete(SnapToGrid);
        }

    }

    private void MoveByGridTr(float v, float h)
    {
        if (h > 0.2 || h < -0.2)
        {
            transform.Translate(new Vector3(
                Mathf.RoundToInt(h) * Time.deltaTime, 0f));
        }

        if (v > 0.2 || v < -0.2)
        {
            transform.Translate(new Vector3(
                0f, Mathf.RoundToInt(v) * Time.deltaTime));
        }

    }

    private void MoveByGrid(float v, float h)
    {
        Vector3 refVel = Vector3.zero;
        float smoothTime = .1f;

        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
        }
        else
        {
            //up = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
        }
        else
        {
            down = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        else
        {
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        else
        {
            //right = false;
        }

        //if (h > 0.2 || h < -0.2)
        if (right)
        {
            transform.position =
                Vector3.Lerp(
                    transform.position,
                    new Vector3(5, 5),
                    smoothTime
                    );

            Debug.Log("move");
        }

        //if (v > 0.2 || v < -0.2)
        if (up)
        {
            transform.position =
                Vector3.SmoothDamp(
                    transform.position,
                    new Vector3(transform.position.x, transform.position.y + Mathf.RoundToInt(v)),
                    ref refVel, smoothTime);
        }

    }

    private void SnapToGrid()
    {
        transform.DOMove(new Vector3(
        Mathf.RoundToInt(transform.position.x),
        Mathf.RoundToInt(transform.position.y),
        Mathf.RoundToInt(transform.position.z)), 0.1f);

    }

}
