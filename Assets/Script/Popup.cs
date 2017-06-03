using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

    bool isTrigger = false;
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
            }
        }
    }



}
