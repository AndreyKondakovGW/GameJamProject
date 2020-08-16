using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject DialogData;
    public GameObject DialoguesManager;
    public bool PlayOnece;

    public void TriggerDialog()
    {

        DialoguesManager.GetComponent<DialoguesManager>().StartDialog(DialogData.transform.GetComponent<Dialog>());
        if (PlayOnece)
        {
            DialogData.transform.GetComponent<Dialog>().CloseDialog();
        }
    }
}
