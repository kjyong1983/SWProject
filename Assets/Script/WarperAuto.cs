using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperAuto : MonoBehaviour {

    public GameObject dest;
    public int destNum;// 1,2,3 : floorNum , 419 : roomNum
    public PlayerController.Direction dir;

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

            //fade out and in
            GameObject.FindObjectOfType<FadeUI>().fadeTrigger = true;

            StartCoroutine(WarpObject(other.gameObject));
            //if dest is floor
            if (destNum < 10)
            {
                other.GetComponent<PlayerLocation>().locationData.floorNum = destNum;
                //other.GetComponent<PlayerController>().prevDir = dir;
                //other.GetComponent<PlayerAnimator>().SetLastMove(other.GetComponent<PlayerController>().DirToVector2(dir));
            }
            //if dest is room
            else if (destNum > 100)
            {
                other.GetComponent<PlayerLocation>().locationData.roomNum = destNum;
            }
            else
            {
                Debug.Log("wrong dest num");
            }       

            Debug.Log("Warp");

        }

    }

    IEnumerator WaitWarpObject()
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
