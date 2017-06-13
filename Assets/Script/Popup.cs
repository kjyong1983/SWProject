using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    public bool isTrigger = false;
    public float coolTimer = 0f;
    public const float coolTimeMax = 5f;

    public string data;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTrigger)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("popup");
                UIManager.instance.ShowPopup(data);
                isTrigger = true;
                coolTimer += coolTimeMax;

                StartCoroutine(TimerActivate());
            }
        }
    }

    IEnumerator TimerActivate()
    {
        //yield return new WaitForSeconds(coolTimer);
        while (coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
            yield return null;
        }
        isTrigger = false;
        yield break;
    }

    private void OnDrawGizmos()
    {
        gameObject.name = data;
    }
}
