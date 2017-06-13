using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public TextAsset csvFile;
    public bool setFalseAtStart;
    public bool setBoxColliderDisabled;
    public bool isTriggered = false;
    public bool canDisappear;
	// Use this for initialization
	void Start () {
        if (setFalseAtStart)
        {
            this.gameObject.SetActive(false);
        }
        if (setBoxColliderDisabled)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
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

        var quest = gameObject.GetComponent<QuestMarker>();

        if (quest != null)
        {
            quest.DoQuest();
        }

        var questChecker = gameObject.GetComponent<QuestChecker>();

        if (quest != null)
        {
            questChecker.isTriggered = true;
        }

        if (canDisappear)
        {
            Destroy(gameObject,1f);
        }
    }
}
