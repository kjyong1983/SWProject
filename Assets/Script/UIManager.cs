using System;
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
    GameObject popup;
    GameObject cutscene;

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
            cutscene = GameObject.Find("Cutscene");
            popup = GameObject.Find("Popup");

            bgmManager = GameObject.Find("BGMManager");

            gameMenu.SetActive(false);
            titleMenuDialogue.SetActive(false);
            settingDialogue.SetActive(false);
            minimap.SetActive(false);
            conversationDialogue.SetActive(false);
            cutscene.SetActive(false);
            popup.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        var playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        playerSpawner.NewGame();//instantiate player but it destroys when scene is loaded
        //Debug.Break();
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
        var player = GameObject.FindWithTag("Player");
        Destroy(player);
        var gameManager = GameObject.FindObjectOfType<GameManager>().gameObject;
        Destroy(gameManager);
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

    public void Save()
    {
        SaveLoad.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("SaveCount"))
        {
            SaveLoad.Load();
        }
        else
        {
            Debug.Log("no saved data");
        }
    }

    public void DeleteSave()
    {
        if (PlayerPrefs.HasKey("SaveCount"))
        {
            SaveLoad.DeleteSave();
        }
        else
        {
            Debug.Log("no saved data");
        }
    }

    public void Interact()
    {
        var player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerInteract>().GetInteract();
    }

    public void ShowCutScene(string data)
    {
        if (data == "cut1")
        {
            var image = cutscene.GetComponent<Image>();
            Sprite temp = Resources.Load<Sprite>("cutscene/dummycutscene2");
            Debug.Log(temp);
            //image.type = Image.Type.Simple;
            //image.preserveAspect = true;
            //image.enabled = true;
            image.sprite = temp;//not working

        }
        cutscene.SetActive(true);
        Debug.Log(data);        
    }

    internal void HideCutScene()
    {
        cutscene.SetActive(false);
    }

    internal void ShowPopup(string data)
    {
        popup.SetActive(true);
        popup.GetComponentInChildren<Text>().text = data;
        StartCoroutine(HideAfterSec());
        
    }
    IEnumerator HideAfterSec()
    {
        yield return new WaitForSeconds(2);

        popup.SetActive(false);
        yield break;
    }


}
