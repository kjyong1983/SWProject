using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
    }
    public void Init()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update () {

    }

    public void SetMove(Vector2 input)
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
    }

    public void SetLastMove(Vector2 input)
    {
        anim.SetFloat("LastMoveX", input.x);
        anim.SetFloat("LastMoveY", input.y);
    }

    public void SetIsMoving(bool val)
    {
        anim.SetBool("IsMoving", val);
    }
}
