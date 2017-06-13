using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarker : MonoBehaviour {

    public int progressValue;
    public bool isTriggered = false;

    private void Update()
    {
        if (isTriggered)
        {
            DoQuest();
        }
    }

    public void DoQuest()
    {
        if (QuestManager.instance == null)
        {
            Debug.Log("QuestManager instance is null");
        }
        QuestManager.instance.questProgress = progressValue;
    }

}
