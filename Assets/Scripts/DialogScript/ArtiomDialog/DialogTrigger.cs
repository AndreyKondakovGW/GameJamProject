using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject DialogData;
    public GameObject DialoguesManager;
    public bool PlayOnece;

    public string NeededItem;
    public GameObject ErrorDialogData;
    public GameObject ErrorDialoguesManager; 

    public void TriggerDialog()
    {
        if ((NeededItem == "") || (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().ItemInHand == NeededItem))
        {
            DialoguesManager.GetComponent<DialoguesManager>().StartDialog(DialogData.transform.GetComponent<Dialog>());
            if (PlayOnece)
            {
                Debug.Log("Close");
                DialogData.transform.GetComponent<Dialog>().CloseDialog();
            }
        }else
        {
            if (ErrorDialoguesManager != null)
            {
                ErrorDialoguesManager.GetComponent<DialoguesManager>().StartDialog(ErrorDialogData.transform.GetComponent<Dialog>());
            }
            
        }
    }
}
