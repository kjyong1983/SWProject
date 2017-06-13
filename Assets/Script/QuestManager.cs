using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance;
    public QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = this;
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public int questProgress = 0;

    public void ChangeCSV(NPC npc, TextAsset file)
    {
        npc.csvFile = file;
    }



}
