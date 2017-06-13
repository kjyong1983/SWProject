using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestChecker : MonoBehaviour {

    //public UnityEvent<NPC, TextAsset> myEvent;
    public class MyEvent : UnityEvent<NPC, TextAsset> { }
    public class DoorEvent : UnityEvent<NPC, NPC, NPC> { }

    MyEvent m_MyEvent;
    DoorEvent doorEvent;

    public NPC npc1;
    public NPC npc2;
    public NPC npc3;

    public TextAsset csvFile;

    public bool isTriggered = false;
    public bool triggerEvent = false;
    public int target;

    private void Start()
    {
        if (m_MyEvent == null)
        {
            m_MyEvent = new MyEvent();
        }
        m_MyEvent.AddListener(QuestManager.instance.ChangeCSV);

        if (doorEvent == null)
        {
            doorEvent = new DoorEvent();
        }
        doorEvent.AddListener(DoorOpenEvent);

    }

    private void Update()
    {
        if (isTriggered)
        {
            triggerEvent = CheckQuest(QuestManager.instance.questProgress, target);
            Debug.Log("QuestChecker : triggerEvent "+ triggerEvent);
            isTriggered = false;
        }
        if (triggerEvent)
        {
            Debug.Log("QuestChecker : triggerEvent true2");
            if (npc1 != null && csvFile != null)
            {
                Debug.Log("myEvent " + m_MyEvent);
                Debug.Log("QuestManager.instance " + QuestManager.instance);
                m_MyEvent.Invoke(npc1, csvFile);
                triggerEvent = false;
            }
            else if (csvFile == null && npc1 != null && npc2 != null)
            {
                Debug.Log("myEvent " + doorEvent);
                Debug.Log("QuestManager.instance " + QuestManager.instance);
                doorEvent.Invoke(npc1, npc2, npc3);
                triggerEvent = false;

            }
            else if (csvFile == null && npc1 != null)
            {
                Debug.Log("Destroy door");
                Destroy(npc1.gameObject);
                triggerEvent = false;

            }
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

    public void DoorOpenEvent(NPC door1, NPC door2, NPC door3)
    {

        Destroy(door1.gameObject);
        Destroy(door2.gameObject);
        Destroy(door3.gameObject);
        Debug.Log("DoEvent 3door");
        //door1.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //door2.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //door3.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        //door1.gameObject.tag = "Ignored";
        //door1.gameObject.tag = "Ignored";
        //door1.gameObject.tag = "Ignored";

    }


}
