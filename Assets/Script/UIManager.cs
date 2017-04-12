using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Go to game Screen");
    }

    public void OpenInGameMenu()
    {
        //RectTransform GameMenu = 
        Debug.Log("Open InGame Menu");
    }

}
