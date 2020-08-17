using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    public RectTransform AnswerPerf;
    public RectTransform Content;

    public GameObject DialogPanel;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void StartDialog(Dialog dialog)
    {
            DialogPanel.SetActive(true);
            Debug.Log("Talk to" + dialog.name);

            nameText.text = dialog.name;

            dialog.StartDialog();
            DisplayNextPhrase(dialog);
    }

    public void DisplayNextPhrase(Dialog dialog)
    {
        if (dialog.EndofDialog())
        {
           EndDialog(); 
        }else
        {
            var phrace = dialog.GetPhrace();
            dialogText.text = phrace.text;
            foreach (Transform child in Content)
            {
                Destroy(child.gameObject);
            }
            foreach (var answer in phrace.answers)
            {
                var instance = GameObject.Instantiate(AnswerPerf.gameObject) as GameObject;
                instance.transform.SetParent(Content, false);
                instance.transform.Find("AnswerVariant").GetComponent<Text>().text = answer.text;
                instance.transform.GetComponent<Button>().onClick.AddListener(delegate {ChangePhrace(dialog, answer.toPhrase, answer.questTrigger);}); 
            }


        }
        
    }
    public void ChangePhrace(Dialog dialog, int id, QuestTrigger triggerquest){
        dialog.ChangePhracse(id);
        DisplayNextPhrase(dialog);
        if (triggerquest != null)
        {
            triggerquest.Trigger();
        }

    }

    public void EndDialog()
    {
        Debug.Log("End");
        DialogPanel.SetActive(false);
        //animator.SetBool("isOne", false);
    }
}
