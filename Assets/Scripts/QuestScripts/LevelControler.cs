using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour
{
    
    public Text CurCharacterName;
    public Text InfoData;
    public QuestContoler Controler;
    public Characters CurCharacter;
    public Transform Leo;
    public Transform Helen;

    public GameObject Camera;

    public void ChangeCharacter()
    {
        if (CurCharacter == Characters.Helen)
        {
            CurCharacterName.text = "Лео";
            CurCharacter = Characters.Leo;
            Camera.GetComponent<CameraController>().ChangeCharacter(Leo);
            Leo.gameObject.SetActive(true);
            Helen.gameObject.SetActive(false);
            Helen.gameObject.GetComponent<Inventory>().InventoryObject.SetActive(false);
            Leo.gameObject.GetComponent<Inventory>().InventoryObject.SetActive(true);
        }
        else
        {
            CurCharacterName.text = "Хэлен";
            CurCharacter = Characters.Helen;
            Camera.GetComponent<CameraController>().ChangeCharacter(Helen);
            Helen.gameObject.SetActive(true);
            Leo.gameObject.SetActive(false);
            Helen.gameObject.GetComponent<Inventory>().InventoryObject.SetActive(true);
            Leo.gameObject.GetComponent<Inventory>().InventoryObject.SetActive(false);
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        if (CurCharacter == Characters.Helen){
            CurCharacterName.text = "Хэлен";
            Helen.gameObject.SetActive(true);
            Leo.gameObject.SetActive(false);
            Camera.GetComponent<CameraController>().ChangeCharacter(Helen);
        }

        if (CurCharacter == Characters.Leo){
            CurCharacterName.text = "Лео";
            Leo.gameObject.SetActive(true);
            Helen.gameObject.SetActive(false);
            Camera.GetComponent<CameraController>().ChangeCharacter(Leo);
        }
        InfoData.text = "Нажмите N чтобы открыть справку";
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}

[System.Serializable]
public enum Characters
{
    Helen,
    Leo
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

    public void ChangeQuestStage(string questName, int newStage,int demandingStage = -100)
    {
       Quest quest = Quests.Where(q => q.titel == questName).First();
       if ((quest != null) && (quest.currentstage >= demandingStage))
       {
           quest.ChangeCurrentstage(newStage);
       }
    }
}

[System.Serializable]
public class Quest
{
    public int _takenstage = 1;
    public int _completdstage = 2;
    public int _faildstage = -1;

    public string titel;
    public QuestStatus globalstate;
    public int currentstage;
    public QuestStage[] stages;

    public void ChangeCurrentstage(int newStage)
    {
       if (globalstate != QuestStatus.Failed)
       {
            currentstage = newStage;
            if (newStage == _takenstage)
            {
                globalstate = QuestStatus.Taken;
            }
            if (newStage == _completdstage)
            {
                globalstate = QuestStatus.Completed;
            }
            if (newStage == _faildstage)
            {
                globalstate = QuestStatus.Failed;
            }
            //InfoData.text = stages.Where(s => s.stage == currentstage).First().playerHint;
       }
    } 
}

[System.Serializable]
public class QuestStage
{
    public int stage;
    public string jurnalВescription;
    public string playerHint;
    public string playerComment;
}
