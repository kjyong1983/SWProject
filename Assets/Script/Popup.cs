using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    public bool isTrigger = false;
    public const float coolTimer = 5f;

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
                StartCoroutine(TimerActivate());
            }
        }
    }

    IEnumerator TimerActivate()
    {
        yield return new WaitForSeconds(coolTimer);
        isTrigger = false;
        yield break;
    }

}
