using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    Animator anim;
    PlayerController p;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        p = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void SetMove(Vector2 input)
    {
        //anim.SetFloat("MoveX", p.Input.x);
        //anim.SetFloat("MoveY", p.Input.y);
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
    }

    public void SetLastMove(Vector2 input)
    {
        //anim.SetFloat("LastMoveX", p.LastInput.x);
        //anim.SetFloat("LastMoveY", p.LastInput.y);
        anim.SetFloat("LastMoveX", input.x);
        anim.SetFloat("LastMoveY", input.y);
    }

    public void SetIsMoving(bool val)
    {
        //anim.SetBool("IsMoving", p.IsMoving);
        anim.SetBool("IsMoving", val);
    }
}
