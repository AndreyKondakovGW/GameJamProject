using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JurnalMenuControler : MonoBehaviour
{
    public Text CurrentQuestName;

    public GameObject JurnalPanel;
    public GameObject LevelControler;

    public RectTransform QuestTitelPerf;
    public RectTransform QuestDescriptionPerf;

    public RectTransform QuestTitelContent;
    public RectTransform QuestDescriptionContent;

    private bool _menuisOpen;
    private bool _curentQuestsisOn;
    private bool _completedQuestsisOn;
    private bool _faildQuestsisOn;

    // Start is called before the first frame update
    void Start()
    {
        _menuisOpen = false;
        _curentQuestsisOn = true;
        _completedQuestsisOn = true;
        _faildQuestsisOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (_menuisOpen)
            {
                CloseMenu();
                _menuisOpen = false;
            }
            else
            {
                OpenMenu();
                _menuisOpen = true;
            }
        }
    }

    public Quest[] CreateQuestList()
    {
        var QuestList = LevelControler.transform.GetComponent<LevelControler>().Controler.Quests.Where(q => q.globalstate != QuestStatus.NotTaken);
        if (!_curentQuestsisOn)
        {
            QuestList = QuestList.Where(q => q.globalstate != QuestStatus.Taken);
        }
        if (!_completedQuestsisOn)
        {
            QuestList = QuestList.Where(q => q.globalstate != QuestStatus.Completed);
        }
        if (!_faildQuestsisOn)
        {
            QuestList = QuestList.Where(q => q.globalstate != QuestStatus.Failed);
        }

        return QuestList.ToArray();

    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        JurnalPanel.SetActive(true);
        var QuestList = CreateQuestList();
        ShowQuests(QuestList);
    }

    public void ShowQuests(Quest[] QuestList)
    {
        foreach (Transform child in QuestTitelContent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in QuestDescriptionContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var quest in QuestList)
        {
            var instance = GameObject.Instantiate(QuestTitelPerf.gameObject) as GameObject;
            instance.transform.SetParent(QuestTitelContent, false);
            instance.transform.Find("Text").GetComponent<Text>().text = quest.titel;
            instance.transform.GetComponent<Button>().onClick.AddListener(delegate {ChangeCurQuest(quest);});
        }
    }

    public void ChangeCurQuest(Quest quest)
    {
        CurrentQuestName.text = quest.titel; 
        foreach (Transform child in QuestDescriptionContent)
        {
            Destroy(child.gameObject);
        }
        var avalibalQuestStage = quest.stages.Where(s => s.stage <= quest.currentstage); 
        foreach (var stage in avalibalQuestStage)
        {
            var instance = GameObject.Instantiate(QuestDescriptionPerf.gameObject) as GameObject;
            instance.transform.SetParent(QuestDescriptionContent, false);
            instance.transform.Find("Text").GetComponent<Text>().text = stage.jurnalВescription;
        }
    } 

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        JurnalPanel.SetActive(false);
    }


    public void curentQuestTicketControl(bool curvalue)
    {
        _curentQuestsisOn = curvalue;
        var QuestList = CreateQuestList();
        ShowQuests(QuestList);
    }

    public void completedQuestTicketControl(bool curvalue)
    {
        _completedQuestsisOn = curvalue;
        var QuestList = CreateQuestList();
        ShowQuests(QuestList);
    }

    public void failedQuestTicketControl(bool curvalue)
    {
        _faildQuestsisOn = curvalue;
        var QuestList = CreateQuestList();
        ShowQuests(QuestList);
    }
}
