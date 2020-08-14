using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    public QuestContoler Controler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public enum QuestStatus
{
    NotTaken,
    Taken,
    Completed,
    Failed
}

[System.Serializable]
public class QuestContoler
{
    public Quest[] Quests;
}

[System.Serializable]
public class Quest
{
    public string titel;
    public QuestStatus globalstate;
    public int currentstage;
    public QuestStage[] stages;
}

[System.Serializable]
public class QuestStage
{
    public int stage;
    public string jurnalВescription;
    public string playerComment;
}
