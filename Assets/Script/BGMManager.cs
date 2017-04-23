using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    public AudioSource bgmSource;

	// Use this for initialization
	void Start () {
        bgmSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //for debugging
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (bgmSource.mute)
            {
                bgmSource.mute = false;
            }
            else
            {
                bgmSource.mute = true;
            }
            Debug.Log("Mute");

        }

	}
}
