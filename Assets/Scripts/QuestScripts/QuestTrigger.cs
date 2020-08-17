using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public GameObject LevelConteroler;
    public string Questname;
    public int demandingQuestState;
    public int NewQueststate;

    public string NeededItem;

    public void Trigger()
    {
        if ((NeededItem == "") || (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().ItemInHand == NeededItem))
        {
            LevelConteroler.GetComponent<LevelControler>().Controler.ChangeQuestStage(Questname, NewQueststate, demandingQuestState);
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
