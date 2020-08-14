using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject DialogData;

    public void TriggerDialog()
    {
        FindObjectOfType<DialoguesManager>().StartDialog(DialogData.transform.GetComponent<Dialog>());
    }
}
