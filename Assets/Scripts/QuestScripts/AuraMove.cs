using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraMove : MonoBehaviour
{
    private bool wasplayed = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!wasplayed)
        {
            if ((col.tag == "Player"))
            {
                gameObject.GetComponent<MoveCharcter>().Move();
                wasplayed = true;
            }
        }
        
        
    }
}
