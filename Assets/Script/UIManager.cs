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

    public void OpenGameMenu()
    {
        GameObject gameMenu = GameObject.Find("GameMenu");
        RectTransform gameMenuPos = gameMenu.GetComponent<RectTransform>();
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        gameMenuPos.position = new Vector3(canvas.rect.width/2, canvas.rect.height/2, 0);

        Debug.Log("Open InGame Menu");

    }

    public void CloseGameMenu()
    {
        GameObject gameMenu = GameObject.Find("GameMenu");
        RectTransform gameMenuPos = gameMenu.GetComponent<RectTransform>();
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        gameMenuPos.position = new Vector3(canvas.rect.width*2, canvas.rect.height*2, 0);

    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenTitleDialogue()
    {
        GameObject Dialogue = GameObject.Find("TitleDialogue");
        RectTransform DialoguePos = Dialogue.GetComponent<RectTransform>();
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        DialoguePos.position = new Vector3(canvas.rect.width / 2, canvas.rect.height / 2, 0);

    }

    public void CloseTitleDialogue()
    {
        GameObject Dialogue = GameObject.Find("TitleDialogue");
        RectTransform DialoguePos = Dialogue.GetComponent<RectTransform>();
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        DialoguePos.position = new Vector3(canvas.rect.width * 2, canvas.rect.height * 2, 0);

    }

}
