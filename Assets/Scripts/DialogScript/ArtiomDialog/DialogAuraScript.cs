using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAuraScript : MonoBehaviour
{
    public GameObject DialogData;
    public GameObject DialoguesManager;
    public bool PlayOnece;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Player")
        {
            DialoguesManager.GetComponent<DialoguesManager>().StartDialog(DialogData.transform.GetComponent<Dialog>());
            if (PlayOnece)
            {
                DialogData.transform.GetComponent<Dialog>().CloseDialog();
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Player")
        {
            DialoguesManager.GetComponent<DialoguesManager>().EndDialog();
        }
        
    }
}
