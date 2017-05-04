using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractTrigger : MonoBehaviour {

    EnemyController e;
    EnemyInteract origin;

	// Use this for initialization
	void Start () {
        e = GetComponentInParent<EnemyController>();
        origin = GetComponentInParent<EnemyInteract>();
        if (e == null)
        {
            Debug.Log("!e");
            Debug.Break();
        }
        if (origin == null)
        {
            Debug.Log("!origin");
            //Debug.Break();
        }
        Debug.Log("origin " + origin);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RaycastHit2D ray
                = Physics2D.Raycast(
                    gameObject.transform.position, 
                    collision.gameObject.transform.position, origin.radius);//변수 수정 필요
            if (ray.collider != null)
            {
                e.p = collision.gameObject;
                Debug.Log("Hunting");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.p = null;
        }

    }
}
