using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public TextAsset csvFile;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(csvFile);
        Debug.Log("NPC : " + csvFile);
        UIManager.instance.ToggleConversationDialogue();
        Debug.Log(UIManager.instance);
        Debug.Log("NPC : start dialogue");
    }
}
