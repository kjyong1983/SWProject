using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperAuto : MonoBehaviour {

    public GameObject dest;
    [SerializeField] private bool warpReady = false;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().fadeTrigger = true;
            Debug.Log("fadeTrigger");
            //Debug.Break();
            other.transform.position = dest.transform.position;//rigidbody가 맨 위에 있어야 작동함.
            Debug.Log("Warp");
        }


        //if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().IsMoving)
        //{
        //    StartCoroutine(WaitWarpObject());
        //    if (warpReady)
        //    {
        //        other.transform.position = dest.transform.position;//rigidbody가 맨 위에 있어야 작동함.
        //    }
        //    warpReady = false;

        //    Debug.Log("teleport");
        //}
    }

    IEnumerator WaitWarpObject(/*GameObject gameObj*/)
    {
        yield return new WaitForSeconds(1f);
        warpReady = true;
        yield break;
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

}
