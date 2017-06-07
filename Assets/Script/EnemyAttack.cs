using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    float attackTimer = 0.1f;
    [SerializeField] bool readyToAttack = true;
    [SerializeField]bool attackTrigger = false;
    [SerializeField]bool isPlayer = false;
    // Use this for initialization
    bool isObstacle = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Attack()
    {
        if (attackTrigger && isPlayer)
        {
            Debug.Log("Attacked");
            //instantiate attack prefab?
            //Debug.Break();
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.hp = 0;
            attackTrigger = false;
            readyToAttack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isObstacle = true;
        isPlayer = true;
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaitForAttack());
            Attack();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isObstacle = false;
        isPlayer = false;
    }

    IEnumerator WaitForAttack()
    {
        if (!readyToAttack)
        {
            yield break;
        }
        yield return new WaitForSeconds(attackTimer);
        readyToAttack = false;
        attackTrigger = true;
        yield break;
    }
}
