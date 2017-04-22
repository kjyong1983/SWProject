using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    GameObject gameMenu;
    GameObject titleMenuDialogue;

	// Use this for initialization
	void Start () {
        gameMenu = GameObject.Find("GameMenu");
        titleMenuDialogue = GameObject.Find("TitleDialogue");

        gameMenu.SetActive(false);
        titleMenuDialogue.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Go to game Screen");
    }

    public void OpenGameMenu()
    {
        gameMenu.SetActive(true);
        Debug.Log("Open InGame Menu");
    }

    public void CloseGameMenu()
    {
        gameMenu.SetActive(false);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenTitleDialogue()
    {
        titleMenuDialogue.SetActive(true);
    }

    public void CloseTitleDialogue()
    {

        titleMenuDialogue.SetActive(false);

    }

}
