using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestChecker : MonoBehaviour {

    //public UnityEvent<NPC, TextAsset> myEvent;
    public class MyEvent : UnityEvent<NPC, TextAsset> { }

    MyEvent m_MyEvent;

    public NPC npc;
    public TextAsset csvFile;

    public bool isTriggered = false;
    //public System.Func<>;
    public bool triggerEvent = false;
    public int target;

    private void Start()
    {
        //if (myEvent == null)
        //{
        //    myEvent = new UnityEvent();
        //}
        //myEvent.AddListener(QuestManager.instance.ChangeCSV);
        if (m_MyEvent == null)
        {
            m_MyEvent = new MyEvent();
        }
        m_MyEvent.AddListener(QuestManager.instance.ChangeCSV);
    }

    private void Update()
    {
        if (isTriggered)
        {
            triggerEvent = CheckQuest(QuestManager.instance.questProgress, target);
            Debug.Log("QuestChecker : triggerEvent true");
            isTriggered = false;
        }
        if (triggerEvent)
        {
            //Debug.Log("myEvent " + myEvent);
            Debug.Log("myEvent " + m_MyEvent);
            Debug.Log("QuestManager.instance " + QuestManager.instance);
            //myEvent.Invoke(npc, csvFile);
            m_MyEvent.Invoke(npc, csvFile);
            triggerEvent = false;
        }
    }

    public bool CheckQuest(int questProgress, int target)
    {
        if (questProgress > target)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }
}
