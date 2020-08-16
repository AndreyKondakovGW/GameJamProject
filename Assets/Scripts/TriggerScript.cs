using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool PlayOnece;
    public bool WasPlayed;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if ((col.tag == "Player") && ((!PlayOnece) || (!WasPlayed)))
        {
            gameObject.GetComponent<QuestTrigger>().Trigger();
            WasPlayed = true;
        }
        
    }
}
