using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    GameObject gameMenu;
    GameObject titleMenuDialogue;
    GameObject settingDialogue;
    GameObject minimap;
    GameObject conversationDialogue;

    GameObject bgmManager;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameMenu = GameObject.Find("GameMenu");
            titleMenuDialogue = GameObject.Find("TitleDialogue");
            settingDialogue = GameObject.Find("settingDialogue");
            minimap = GameObject.Find("Minimap");
            conversationDialogue = GameObject.Find("ConversationDialogue");


            bgmManager = GameObject.Find("BGMManager");

            gameMenu.SetActive(false);
            titleMenuDialogue.SetActive(false);
            settingDialogue.SetActive(false);
            minimap.SetActive(false);
            conversationDialogue.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
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

    public void OpenSettingDialogue()
    {
        settingDialogue.SetActive(true);
    }

    public void CloseSettingDialogue()
    {
        settingDialogue.SetActive(false);
    }

    public void ToggleConversationDialogue()
    {
        if (!conversationDialogue.activeSelf)
        {
            conversationDialogue.SetActive(true);
        }
        else
        {
            conversationDialogue.SetActive(false);
        }
    }

    public void BGMMute(Button button)
    {
        var bgm = bgmManager.GetComponent<BGMManager>();
        //var buttonText = GameObject.Find("BGM").GetComponentInChildren<Text>();
        var buttonText = button.GetComponentInChildren<Text>();

        Debug.Log(buttonText);

        if (!bgm.bgmSource.mute)
        {
            bgm.bgmSource.mute = true;
            buttonText.text = "BGM Off";

        }
        else
        {
            bgm.bgmSource.mute = false;
            buttonText.text = "BGM On";

        }

    }

    public void Map()
    {
        if (!minimap.activeSelf)
        {
            minimap.SetActive(true);
        }
        else
            minimap.SetActive(false);
    }

}
