using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public TextAsset csvFile;
    public bool setFalseAtStart;
    public bool isTriggered = false;
    public bool canDisappear;
	// Use this for initialization
	void Start () {
        if (setFalseAtStart)
        {
            this.gameObject.SetActive(false);
        }
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
        isTriggered = true;

        if (canDisappear)
        {
            //this.GetComponentInChildren<SpriteRenderer>().enabled = false;
            //this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
