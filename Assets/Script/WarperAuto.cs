using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperAuto : MonoBehaviour {

    public GameObject dest;


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
            other.gameObject.GetComponent<PlayerController>().canMove = false;
            //other.gameObject.GetComponent<PlayerController>().fadeTrigger = true;
            //Debug.Log("fadeTrigger");
            //Debug.Break();


            StartCoroutine(WarpObject(other.gameObject));

            //other.transform.position = dest.transform.position;//rigidbody가 맨 위에 있어야 작동함.
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
        yield break;
    }

    IEnumerator WarpObject(GameObject player)
    {
        player.gameObject.GetComponent<PlayerController>().fadeTrigger = true;
        Debug.Log("fadeTrigger on");
        yield return new WaitForSeconds(0.3f);
        player.transform.position = dest.transform.position;
        Debug.Log("fadeTrigger");
        yield return new WaitForSeconds(0.3f);
        player.GetComponent<PlayerController>().canMove = true;
        yield break;
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

}
