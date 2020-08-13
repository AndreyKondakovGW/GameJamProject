using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;

    public Animator animator;
    public GameObject DialogPanel;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialog(Dialog dialog)
    {
        //animator.SetBool("isOne", true);
        DialogPanel.SetActive(true);
        Debug.Log("Talk to" + dialog.name);

        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    public void EndDialog()
    {
        Debug.Log("End");
        DialogPanel.SetActive(false);
        //animator.SetBool("isOne", false);
    }
}
